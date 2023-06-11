using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.Models.StockHandlerProcessorModels;
using WizardStockFinder.Services.Repositories.Interfaces;
using WizardStockFinder.Services.Services.Interfaces;

namespace WizardStockFinder.Services.Services
{
    public class StockDataService : IStockDataService
    {
        private readonly IStockDataRepository _stockDataRepository;

        public StockDataService(IStockDataRepository stockDataRepository)
        {
            _stockDataRepository = stockDataRepository;
        }

        public async Task InsertData(StockData data, string symbol, string interval)
        {
            await _stockDataRepository.InsertData(data, symbol, interval);
        }

        public async Task<StockData> GetData(string symbol, string interval)
        {
            return await _stockDataRepository.GetData(symbol, interval);
        }
    }
}
