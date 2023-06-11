using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace WizardStockFinder.Models.StockHandlerProcessorModels
{
    public class StockData
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }

        [JsonProperty("Time Series (5min)")]
        public Dictionary<string, TimeSeriesData> TimeSeries { get; set; }
    }
}
