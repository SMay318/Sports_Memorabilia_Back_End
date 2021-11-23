using eCommerceStarterCode.Data;
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
    public class ShoppingCartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userid}"), Authorize]
        public IActionResult GetShoppingCartForUser(string userid)
        {
            var usercart = _context.ShoppingCarts.Include(uc => uc.User).Include(uc => uc.Product).Where(uc => uc.UserId == userid);
            if (usercart == null)
            {
                return NotFound();
            }

            return Ok(usercart);
        }


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
    }
}
