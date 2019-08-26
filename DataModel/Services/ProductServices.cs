using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.DataAccess;
using DataModel.EntityModel;

namespace DataModel.Services
{
    /// <summary>
    /// Offers services for product specific CRUD operations
    /// </summary>
    public class ProductServices : IProductServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductServices()
        {
            _unitOfWork = new UnitOfWork();
        }
        /// <summary>
        /// Fetches product details by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product GetProductById(int productId)
        {
             return _unitOfWork.ProductRepository.GetByID(productId);
           
        }

        /// <summary>
        /// Fetches all the products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return _unitOfWork.ProductRepository.GetAll().ToList();
        
        }


        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        public int CreateProduct(Product productEntity)
        {
           
                var product = new Product
                {
                    ProductName = productEntity.ProductName
                };
                _unitOfWork.ProductRepository.Insert(product);
                _unitOfWork.Save();
                return product.ProductId;
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        public bool UpdateProduct(int productId, Product productEntity)
        {
            var success = false;
            if (productEntity != null)
            {
             
                    var product = _unitOfWork.ProductRepository.GetByID(productId);
                    if (product != null)
                    {
                        product.ProductName = productEntity.ProductName;
                        _unitOfWork.ProductRepository.Update(product);
                        _unitOfWork.Save();
                        success = true;
                    }
            }
            return success;
        }


        /// <summary>
        /// Deletes a particular product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productId)
        {
            var success = false;
            if (productId > 0)
            {
               
                    var product = _unitOfWork.ProductRepository.GetByID(productId);
                    if (product != null)
                    {

                        _unitOfWork.ProductRepository.Delete(product);
                        _unitOfWork.Save();
                        success = true;
                    }
            }
            return success;
        }
    }
}
