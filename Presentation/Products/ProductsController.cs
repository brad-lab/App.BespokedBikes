using App.BespokedBikes.Application.Products;
using App.BespokedBikes.Application.Products.Commands.CreateProduct;
using App.BespokedBikes.Application.Products.Queries.GetProductsList;
using App.BespokedBikes.Presentation.Products.Models;
using App.BespokedBikes.Presentation.Products.Services;
using App.BespokedBikes.Presentation.Sales.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.BespokedBikes.Presentation.Products
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IGetProductsListQuery _query;
        private readonly ICreateProductViewModelFactory _factory;
        private readonly ICreateProductCommand _createcommand;
        private readonly IProductValidator _productValidator;

        public ProductsController(IGetProductsListQuery query, 
                                    ICreateProductViewModelFactory factory,
                                    ICreateProductCommand command,
                                    IProductValidator productValidator)
        {
            _query = query;
            _factory = factory;
            _createcommand = command;
            _productValidator = productValidator;
        }
        [Route("index")]
        public ViewResult Index()
        {
            var products = _query.Execute();

            return View(products);
        }

        [Route("create")]
        public ViewResult Create()
        {
            var viewModel = _factory.Create();

            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var model = viewModel.Product;

            // Application-layer validation to prevent duplicates and return user-friendly message
            var validation = await _productValidator.ValidateNoDuplicateAsync(model.Name, model.Manufacturer, model.Style);
            if (!validation.IsValid)
            {
                ModelState.AddModelError(string.Empty, validation.ErrorMessage);
                return View(viewModel);
            }

            _createcommand.Execute(model);

            return RedirectToAction("index", "products");
        }
    }
}