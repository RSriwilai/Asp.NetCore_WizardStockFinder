using System.Globalization;
using Newtonsoft.Json;
using WizardStockFinder.Models.StockHandlerProcessorModels;
using WizardStockFinder.Services.Interfaces;
using WizardStockFinder.Services.Services.Interfaces;

namespace WizardStockFinder.Services.Processors
{
    public class StockHandlerProcessor : IStockHandlerProcessor
    {
        private readonly ILogger<StockHandlerProcessor> _logger;
        private readonly IStockDataService _stockDataService;

        public StockHandlerProcessor(ILogger<StockHandlerProcessor> logger, IStockDataService stockDataService)
        {
            _logger = logger;
            _stockDataService = stockDataService;
        }

        public async Task ExecuteAsync()
        {
            var timeSeries = "TIME_SERIES_INTRADAY";
            var symbols = new List<string> { "AAPL", "GOOGL", "MSFT" };
            var interval = "5min";
            var outputSize = "compact";

            var alphavantageApiKey = "YL7BEP6G6N0VSOHU";

            foreach (var symbol in symbols)
            {
                var request = new StockHandlerProcessorRequest
                {
                    TimeSeries = timeSeries,
                    Symbol = symbol,
                    Interval = interval,
                    OutputSize = outputSize
                };

                await GetAndInsertStockData(request, alphavantageApiKey);
            }
        }

        private async Task GetAndInsertStockData(StockHandlerProcessorRequest request, string apiKey)
        {
            string queryUrl = $"https://www.alphavantage.co/query?function={request.TimeSeries}&symbol={request.Symbol}&interval={request.Interval}&outputsize={request.OutputSize}&apikey={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(queryUrl);
                string jsonString = await response.Content.ReadAsStringAsync();

                var stockData = JsonConvert.DeserializeObject<StockData>(jsonString);

                if (stockData != null)
                {
                    var lastFetchedDateTime = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                    stockData.MetaData.LastFetched = lastFetchedDateTime;

                    await _stockDataService.InsertData(stockData, request.Symbol, request.Interval);
                }
            }
        }

    }

}