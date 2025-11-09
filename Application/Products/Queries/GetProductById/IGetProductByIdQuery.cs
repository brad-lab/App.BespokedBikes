using App.BespokedBikes.Application.Products.Queries.GetProductsList;

namespace App.BespokedBikes.Application.Products.Queries.GetProductById
{
    public interface IGetProductByIdQuery
    {
        /// <summary>
        /// Returns the employee DTO for the given id or null if not found.
        /// </summary>
        ProductModel Execute(int id);
    }
}