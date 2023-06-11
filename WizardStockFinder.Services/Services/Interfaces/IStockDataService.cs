using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.Models.StockHandlerProcessorModels;

namespace WizardStockFinder.Services.Services.Interfaces
{
    public interface IStockDataService
    {
        Task InsertData(StockData data, string symbol, string interval);
        Task<StockData> GetData(string symbol, string interval);
    }
}
