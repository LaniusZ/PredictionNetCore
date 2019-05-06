using Microsoft.ML.Data;

namespace myMLApp.Entities
{
    public class DataEntity
    {
        [LoadColumn(0)]
        public float Num;

        [LoadColumn(1)]
        public string Label;
    }
}
