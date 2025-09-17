using Microsoft.AspNetCore.Mvc;
using MLNETSample.ML;

namespace MLNETSample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewsController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// List all reviews stored in the dataset.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var reviews = _reviewService.GetReviews();
            return Ok(reviews);
        }
    }
}
