using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.BusinessLogic.Interfaces;
using WizardStockFinder.Models.StockHandlerProcessorModels;
using WizardStockFinder.Utilis.Helpers;

namespace WizardStockFinder.BusinessLogic.Services
{
    public class ScreenerService : IScreenerService
    {
        public async Task<StockData> GetStockData()
        {
            var stockData = JsonFileHelper.ReadFromStockDataJson();

            return await Task.FromResult(stockData);
        }
    }
}
