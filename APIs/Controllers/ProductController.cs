using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIs.ActionFilters;
using APIs.Filters;
using AttributeRouting.Web.Mvc;
using DataModel.EntityModel;
using DataModel.Services;

namespace APIs.Controllers
{
    //[RoutePrefix("v1/Products/Product")]
     [AuthorizationRequired]
   // [ApiAuthenticationFilter]
    public class ProductController : ApiController
    {
        private readonly IProductServices _productServices;


        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public ProductController()
        {
            _productServices = new ProductServices();
        }

        #endregion

      //  [GET("allproducts")]
        // GET api/product
        public HttpResponseMessage Get()
        {
            var products = _productServices.GetAllProducts();
            if (products != null)
            {
                var productEntities = products as List<Product> ?? products.ToList();
                if (productEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, productEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }

        // GET api/product/5
        public HttpResponseMessage Get(int id)
        {
            var product = _productServices.GetProductById(id);
            if (product != null)
                return Request.CreateResponse(HttpStatusCode.OK, product);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/product
        public int Post([FromBody] Product Product)
        {
            return _productServices.CreateProduct(Product);
        }

        // PUT api/product/5
        public bool Put(int id, [FromBody]Product Product)
        {
            if (id > 0)
            {
                return _productServices.UpdateProduct(id, Product);
            }
            return false;
        }

        // DELETE api/product/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _productServices.DeleteProduct(id);
            return false;
        }
    }
}