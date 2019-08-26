using System.Collections.Generic;

using DataModel.EntityModel;

namespace DataModel.Services
{
  public  interface IProductServices
    {
        Product GetProductById(int productId);
        IEnumerable<Product> GetAllProducts();
        int CreateProduct(Product productEntity);
        bool UpdateProduct(int productId, Product productEntity);
        bool DeleteProduct(int productId);
    }
}
