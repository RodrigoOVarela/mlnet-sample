using Microsoft.ML;
using System.Text.Json;

namespace MLNETSample.ML;

public class SentimentModel
{
    private readonly MLContext _mlContext;
    private ITransformer _model;

    public SentimentModel()
    {
        _mlContext = new MLContext();
        _model = TrainModel();
    }

    private ITransformer TrainModel()
    {
        // load JSON
        var jsonPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "MLNETSample.Data", "reviews.json");
        var json = File.ReadAllText(jsonPath);
        var samples = JsonSerializer.Deserialize<List<ReviewData>>(json) ?? new List<ReviewData>();

        // convert to IDataView
        var data = _mlContext.Data.LoadFromEnumerable(samples);

        var pipeline = _mlContext.Transforms.Text.FeaturizeText("Features", nameof(ReviewData.Text))
            .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression());

        return pipeline.Fit(data);
    }

    public ReviewPrediction Predict(string text)
    {
        var predEngine = _mlContext.Model.CreatePredictionEngine<ReviewData, ReviewPrediction>(_model);
        return predEngine.Predict(new ReviewData { Text = text });
    }
}
