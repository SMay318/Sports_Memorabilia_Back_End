using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet, Authorize]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();

            return Ok(products);
        }


        [HttpGet("{id}"), Authorize]

        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost, Authorize]

        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}"), Authorize]

        public IActionResult UpdateProductById(int id, [FromBody] Product value )
        {
            var product = _context.Products.FirstOrDefault(product => product.Id == id);
            product.Name = value.Name;
            product.Description = value.Description;
            product.Price = value.Price;
            product.Category = value.Category;
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok();

        }
    }
}
