using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using WizardStockFinder.Models.StockHandlerProcessorModels;
using WizardStockFinder.Utilis.Helpers;

namespace WizardStockFinder.Services.Processors
{
    public class StockHandlerProcessor : BackgroundService
    {
        private readonly ILogger<StockHandlerProcessor> _logger;

        public StockHandlerProcessor(ILogger<StockHandlerProcessor> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timeSeries = "TIME_SERIES_INTRADAY";
            var symbol = "AAPL";
            var interval = "5min";
            var outputSize = "compact";
            var request = new StockHandlerProcessorRequest
            {
                TimeSeries = timeSeries, 
                Symbol = symbol, 
                Interval = interval, 
                OutputSize = outputSize
            };

            var stockData = await GetStockData(request);
        }

        private async Task<StockData> GetStockData(StockHandlerProcessorRequest request)
        {
            var alphavantageApiKey = "YL7BEP6G6N0VSOHU";
            string queryUrl =
                $"https://www.alphavantage.co/query?function={request.TimeSeries}&symbol={request.Symbol}&interval={request.Interval}&outputsize={request.OutputSize}&apikey={alphavantageApiKey}";


            var stockData = new StockData();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(queryUrl);
                string jsonString = await response.Content.ReadAsStringAsync();
                
                JsonFileHelper.WriteToStockDataJsonFile(jsonString);

                stockData = JsonConvert.DeserializeObject<StockData>(jsonString);
            }

            return stockData;
        }

    }

}