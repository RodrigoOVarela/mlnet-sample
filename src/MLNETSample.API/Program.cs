using MLNETSample.ML;

var builder = WebApplication.CreateBuilder(args);

// Registrar o modelo como Singleton
builder.Services.AddSingleton<SentimentModel>();

var app = builder.Build();

app.MapPost("/analyze-review", (ReviewRequest request, SentimentModel model) =>
{
    var prediction = model.Predict(request.Text);

    return Results.Ok(new
    {
        Review = request.Text,
        Sentiment = prediction.PredictedLabel ? "Positive" : "Negative",
        Confidence = prediction.Probability
    });
});


app.Run();
