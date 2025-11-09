using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using App.BespokedBikes.Application.Common;
using App.BespokedBikes.Application.Products;
using App.BespokedBikes.Application.Interfaces; // or wherever IDatabaseService lives

namespace App.BespokedBikes.Application.Products
{
    public class ProductValidator : IProductValidator
    {
        private readonly IDatabaseService _db;

        public ProductValidator(IDatabaseService db) => _db = db;

        public async Task<ValidationResult> ValidateNoDuplicateAsync(string name, string manufacturer, string style)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(manufacturer) || string.IsNullOrWhiteSpace(style))
                return ValidationResult.Success;

            var nName = name.Trim().ToLowerInvariant();
            var nMan = manufacturer.Trim().ToLowerInvariant();
            var nStyle = style.Trim().ToLowerInvariant();

            var exists = await _db.Products
                .AsNoTracking()
                .AnyAsync(p =>
                    EF.Functions.Like(p.Name.Trim().ToLower(), nName) &&
                    EF.Functions.Like(p.Manufacturer.Trim().ToLower(), nMan) &&
                    EF.Functions.Like(p.Style.Trim().ToLower(), nStyle));

            if (exists)
                return new ValidationResult(false, "A product with the same name, manufacturer and style already exists.");

            return ValidationResult.Success;
        }
    }
}