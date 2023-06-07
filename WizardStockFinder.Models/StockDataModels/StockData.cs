using Newtonsoft.Json;

namespace WizardStockFinder.Models.StockHandlerProcessorModels
{
    public class StockData
    {
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }

        [JsonProperty("Time Series (5min)")]
        public Dictionary<string, TimeSeriesData> TimeSeries { get; set; }
    }
}
