using eCommerceStarterCode.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        //        [HttpGet, Authorize]
        //        public IActionResult GetShoppingCartForUser()
        //        {
        //            var userId = User.FindFirstValue("id");
        //            var shoppingcart = _context.ShoppingCarts.Include().Where(products => products.UserId == userId);
        //            if (shoppingcart == null)
        //            {
        //                return NotFound();
        //            }

        //            return Ok(shoppingcart);
        //        }


        //        [HttpGet("{id}")]

        //        public IActionResult GetProductById(int id)
        //        {
        //            var products = _context.Products.Include(products => products.User);
        //            if (products == null)
        //            {
        //                return NotFound();
        //            }

        //            return Ok(products);
        //        }

        //        [HttpPost, Authorize]

        //        public IActionResult CreateProduct(Product product)
        //        {
        //            _context.Products.Add(product);
        //            _context.SaveChanges();
        //            return Ok();
        //        }
    }
}
