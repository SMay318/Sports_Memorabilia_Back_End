using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{productid}")]

        public IActionResult GetAllReviewsByProductId(int productid)
        {
            var userReview = _context.Reviews.Include(ur => ur.Product).Where(ur => ur.ProductId == productid);
            if (userReview == null)
            {
                return NotFound();
            }

            return Ok(userReview);
        }

        [HttpPost]

        public IActionResult CreateReview([FromBody]Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteReview(int id)
        {
            var review = _context.Reviews.FirstOrDefault(review => review.Id == id);
            _context.Remove(review);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateReviewById(int id, [FromBody] Review value)
        {
            var review = _context.Reviews.FirstOrDefault(review => review.Id == id);
            review.Comment = value.Comment;
            review.Rating = value.Rating;
            _context.Reviews.Update(review);
            _context.SaveChanges();
            return Ok();

        }
    }
}
