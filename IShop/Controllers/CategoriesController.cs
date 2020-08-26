using IShop.BusinessLogic.Services;
using IShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IShop.Controllers
{
    public class CategoriesController : ApiController
    {
        private ICategoryService _categoryService = new CategoryService();
        private IProductService _productService = new ProductService();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_categoryService.Get(id));
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Category category)
        {
            _categoryService.Add(category);
            
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Category category)
        {
            _categoryService.Update(category);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _categoryService.Delete(id);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult SortByName()
        {
            return Ok(_categoryService.SortByName());
        }

        [HttpGet]
        public IHttpActionResult GetAllProductsByCategory(int id)
        {
            var products = _productService.GetAll().Where(x => x.CategoryId == id);

            return Ok(products);
        }
    }
}
