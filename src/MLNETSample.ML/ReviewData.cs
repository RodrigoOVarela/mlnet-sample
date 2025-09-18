namespace MLNETSample.ML;

public enum SentimentType
{
    Positive,
    Negative
}

public class ReviewData
{
    public string Text { get; set; } = string.Empty;
    public bool Label { get; set; }
}

public class ReviewPrediction
{
    public bool PredictedLabel { get; set; }
    public float Probability { get; set; }
}
