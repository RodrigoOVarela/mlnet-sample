using Microsoft.AspNetCore.Mvc;
using MLNETSample.ML;

namespace MLNETSample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SentimentController : ControllerBase
    {
        private readonly SentimentModel _service;

        public SentimentController(SentimentModel service)
        {
            _service = service;
        }

        /// <summary>
        /// Predicts sentiment (Positive/Negative) for a given review text.
        /// </summary>
        /// <param name="request">Review text to analyze</param>
        /// <returns>Predicted sentiment and confidence score</returns>
        [HttpPost("analyze-review")]
        public IActionResult Predict([FromBody] SentimentRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Review))
                return BadRequest("Review text cannot be empty.");

            var result = _service.Predict(request.Review);
            return Ok(result);
        }
    }

    public class SentimentRequest
    {
        public string Review { get; set; } = string.Empty;
    }
}
