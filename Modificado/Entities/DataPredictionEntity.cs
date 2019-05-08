using Microsoft.ML.Data;

namespace myMLApp.Entities
{
    public class DataPredictionEntity
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabels;
    }
}
