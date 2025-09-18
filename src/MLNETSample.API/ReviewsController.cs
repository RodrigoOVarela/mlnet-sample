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
        /// <param name="sentiment">Filter reviews by sentiment (Positive, Negative). If not provided, returns all reviews.</param>
        [HttpGet]
        public IActionResult GetAll([FromQuery] SentimentType? sentiment = null)
        {
            var reviews = _reviewService.GetReviews(sentiment);
            return Ok(reviews);
        }
    }
}
