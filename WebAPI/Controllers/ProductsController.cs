using BusinessLogic.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // Loosely coupled => Gevşek bağlılık, Soyuta bağlılık
        // naming convention
        // IoC Container -- Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);

            var result = _productService.GetAll();

            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetByCategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            Thread.Sleep(1000);

            var result = _productService.GetAllByCategoryId(categoryId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);

            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
