using IShop.BusinessLogic.Services;
using IShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace IShop.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductService _productService = new ProductService();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_productService.Get(id));
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Product product)
        {
            _productService.Add(product);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Product product)
        {
            _productService.Update(product);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _productService.Delete(id);

            return Ok();
        }
    }
}
