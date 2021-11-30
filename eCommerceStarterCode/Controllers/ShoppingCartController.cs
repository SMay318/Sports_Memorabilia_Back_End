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
    [ApiController, Authorize]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userid}")]
        public IActionResult GetShoppingCartForUser(string userid)
        {
            var usercart = _context.ShoppingCarts.Include(uc => uc.User).Include(uc => uc.Product).Where(uc => uc.UserId == userid);
            if (usercart == null)
            {
                return NotFound();
            }

            return Ok(usercart);
        }

        [HttpPut("{userid}")]
        public IActionResult UpdateShoppingCartByUserId(string userid, [FromBody] ShoppingCart value)
        {
            var shoppingcart = _context.ShoppingCarts.FirstOrDefault(shoppingcart => shoppingcart.UserId == userid);
            shoppingcart.Quantity = value.Quantity;
            _context.ShoppingCarts.Update(shoppingcart);
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{userid}/{productid}")]

        public IActionResult DeleteProductFromShoppingCart(string userid, int productid)
        {
            var product = _context.ShoppingCarts.Where(shoppingcart => shoppingcart.UserId == userid).FirstOrDefault(shoppingcart => shoppingcart.ProductId == productid);
            _context.Remove(product);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]

        public IActionResult CreateShoppingCart([FromBody]ShoppingCart shoppingcart)
        {
            _context.ShoppingCarts.Add(shoppingcart);
            _context.SaveChanges();
            return Ok();
        }
    }
}
