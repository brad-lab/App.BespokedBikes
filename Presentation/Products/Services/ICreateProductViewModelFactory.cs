using App.BespokedBikes.Presentation.Products.Models;
using App.BespokedBikes.Presentation.Sales.Models;

namespace App.BespokedBikes.Presentation.Products.Services
{
    public interface ICreateProductViewModelFactory
    {
        CreateProductViewModel Create();
    }
}
