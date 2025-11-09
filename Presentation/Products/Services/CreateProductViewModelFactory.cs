using App.BespokedBikes.Application.Products.Commands.CreateProduct;
using App.BespokedBikes.Presentation.Products.Models;
using App.BespokedBikes.Presentation.Sales.Models;

namespace App.BespokedBikes.Presentation.Products.Services
{
    public class CreateProductViewModelFactory: ICreateProductViewModelFactory
    {
        public CreateProductViewModelFactory() {

        }

        public CreateProductViewModel Create()
        {
            var viewModel = new CreateProductViewModel();

            viewModel.Product = new CreateProductModel();

            return viewModel;
        }
    }
}
