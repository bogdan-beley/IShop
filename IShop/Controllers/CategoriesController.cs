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
            var category = _categoryService.Get(id);

            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Category category)
        {
            if (category == null)
                return BadRequest("Category can't be null!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            _categoryService.Add(category);
            
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Category category)
        {
            if (category == null)
                return BadRequest("Category can't be null!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _categoryService.Update(category);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var category = _categoryService.Get(id);

            if (category != null)
            {
                _categoryService.Delete(id);

                return Ok();
            }
            else
            {
                return NotFound();
            }  
        }

        [HttpGet]
        public IHttpActionResult SortByName()
        {
            return Ok(_categoryService.SortByName());
        }

        [HttpGet]
        public IHttpActionResult GetAllProductsByCategory(int id)
        {
            var category = _productService.Get(id);
            
            if (category == null)
                return NotFound();

            var products = _productService.GetAll().Where(x => x.CategoryId == id);

            return Ok(products);
        }
    }
}
