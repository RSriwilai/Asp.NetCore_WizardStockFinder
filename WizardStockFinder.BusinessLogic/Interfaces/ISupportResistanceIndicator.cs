using WizardStockFinder.Models.StockDataModels.SupportResistanceModels;

namespace WizardStockFinder.BusinessLogic.Interfaces;

public interface ISupportResistanceIndicator
{
    Task<StockDataWithSupportResistanceDto> CalculateSupportResistance();
}