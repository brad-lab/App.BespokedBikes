using System.Threading.Tasks;
using App.BespokedBikes.Application.Common;

namespace App.BespokedBikes.Application.Products
{
    public interface IProductValidator
    {
        Task<ValidationResult> ValidateNoDuplicateAsync(string name, string manufacturer, string style);
    }
}