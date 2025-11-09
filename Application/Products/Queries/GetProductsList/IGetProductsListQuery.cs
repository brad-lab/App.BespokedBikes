using System.Collections.Generic;

namespace App.BespokedBikes.Application.Products.Queries.GetProductsList
{
    public interface IGetProductsListQuery
    {
        List<ProductModel> Execute();
    }
}