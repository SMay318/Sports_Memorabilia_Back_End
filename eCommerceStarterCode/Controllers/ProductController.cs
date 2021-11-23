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

        [HttpPost]

        public IActionResult CreateProduct([FromBody]Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok();
        }
    }
}
