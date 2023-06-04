using WizardStockFinder.Models.StockHandlerProcessorModels;

namespace WizardStockFinder.BusinessLogic.Interfaces;

public interface IScreenerService
{
    Task<StockData> GetStockData();
}