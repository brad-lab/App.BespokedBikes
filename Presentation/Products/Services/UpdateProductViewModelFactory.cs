using App.BespokedBikes.Application.Products.Commands.UpdateProduct;
using App.BespokedBikes.Presentation.Products.Models;

namespace App.BespokedBikes.Presentation.Products.Services
{
    public class UpdateProductViewModelFactory : IUpdateProductViewModelFactory
    {
        public UpdateProductViewModelFactory()
        {
        }
        public UpdateProductViewModel Create()
        {
            var viewModel = new UpdateProductViewModel();
            viewModel.Product = new UpdateProductModel();
            return viewModel;
        }
    }
}
