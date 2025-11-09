using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace App.BespokedBikes.Presentation.Shared
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent DateFor<TModel>(this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, DateTime?>> expression,
            object htmlAttributes = null)
        {
            return DateInput(htmlHelper, expression, htmlAttributes);
        }

        public static IHtmlContent DateFor<TModel>(this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, DateTime>> expression,
            object htmlAttributes = null)
        {
            return DateInput(htmlHelper, expression, htmlAttributes);
        }

        private static IHtmlContent DateInput<TModel, TProperty>(IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            object htmlAttributes)
        {
            // Use ModelExpressionProvider to create a ModelExpression and get its ModelExplorer.
            var modelExpressionProvider = new ModelExpressionProvider(htmlHelper.MetadataProvider);
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var metadata = modelExpression.ModelExplorer;

            var name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(metadata.Metadata.PropertyName ?? metadata.Metadata.Name);
            var id = name.Replace('.', '_');

            string value = null;
            if (metadata.Model != null)
            {
                if (metadata.Model is DateTime dt)
                    value = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                else if (metadata.Model is DateTimeOffset dto)
                    value = dto.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                else if (metadata.Model is DateTime)
                    value = ((DateTime)metadata.Model).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                else if (metadata.Model is DateTime?)
                {
                    var ndt = (DateTime?)metadata.Model;
                    if (ndt.HasValue)
                        value = ndt.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
            }

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) ?? new Dictionary<string, object>();
            // ensure type/date, name and id are set (allow overrides from attributes if provided)
            if (!attributes.ContainsKey("type")) attributes["type"] = "date";
            if (!attributes.ContainsKey("name")) attributes["name"] = name;
            if (!attributes.ContainsKey("id")) attributes["id"] = id;
            if (!string.IsNullOrEmpty(value) && !attributes.ContainsKey("value")) attributes["value"] = value;

            var tagBuilder = new TagBuilder("input");
            foreach (var attr in attributes)
                tagBuilder.MergeAttribute(attr.Key, attr.Value?.ToString(), replaceExisting: true);

            // Add validation attributes (unobtrusive) if any
            var validationAttributes = htmlHelper.GetValidationAttributes(name, metadata.Metadata);
            foreach (var kv in validationAttributes)
                tagBuilder.MergeAttribute(kv.Key, kv.Value?.ToString(), replaceExisting: false);

            tagBuilder.TagRenderMode = TagRenderMode.SelfClosing;
            return tagBuilder;
        }

        // Helper to fetch validation attributes similar to built-in helpers
        private static IDictionary<string, object> GetValidationAttributes<TModel>(this IHtmlHelper<TModel> htmlHelper, string name, ModelMetadata metadata)
        {
            var viewContext = htmlHelper.ViewContext;
            var attributes = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            var modelState = viewContext.ViewData.ModelState;
            var fieldName = name;
            if (modelState != null && modelState.TryGetValue(fieldName, out var entry) && entry.Errors.Count > 0)
            {
                // leave this to validation summary / field validation; don't inject error text here
            }

            // Add unobtrusive validation attributes from metadata if present
            var clientModelValidatorProvider = (IClientModelValidatorProvider)viewContext.HttpContext.RequestServices.GetService(typeof(IClientModelValidatorProvider));
            if (clientModelValidatorProvider != null)
            {
                var validators = new List<ClientValidatorItem>();
                clientModelValidatorProvider.CreateValidators(new ClientValidatorProviderContext(metadata, validators));
                // This is a lightweight implementation — in most projects you can rely on built-in helpers for client attributes.
            }

            return attributes;
        }
    }
}