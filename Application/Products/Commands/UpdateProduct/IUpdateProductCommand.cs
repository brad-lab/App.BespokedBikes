namespace App.BespokedBikes.Application.Products.Commands.UpdateProduct
{
    public interface IUpdateProductCommand
    {
        /// <summary>
        /// Updates an existing product based on the provided model.
        /// </summary>
        void Execute(UpdateProductModel model);
    }
}