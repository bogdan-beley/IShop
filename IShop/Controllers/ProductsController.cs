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
            var product = _productService.Get(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Product can't be null!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _productService.Add(product);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Product can't be null!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _productService.Update(product);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var product = _productService.Get(id);
            if (product == null)
                return NotFound();

            _productService.Delete(id);

            return Ok();
        }
    }
}
