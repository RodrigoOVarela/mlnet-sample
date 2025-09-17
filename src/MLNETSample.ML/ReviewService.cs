using System.Text.Json;

namespace MLNETSample.ML
{
    public class ReviewService
    {
        private readonly string _jsonPath;

        public ReviewService()
        {
            _jsonPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "MLNETSample.Data", "reviews.json");
        }

        /// <summary>
        /// Load all reviews from the JSON file.
        /// </summary>
        public IEnumerable<ReviewData> GetReviews()
        {
            if (!File.Exists(_jsonPath))
                return Enumerable.Empty<ReviewData>();

            var json = File.ReadAllText(_jsonPath);
            return JsonSerializer.Deserialize<List<ReviewData>>(json) ?? new List<ReviewData>();
        }
    }
}
