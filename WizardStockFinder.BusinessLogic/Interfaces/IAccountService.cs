using WizardStockFinder.Models.AccountModels;

namespace WizardStockFinder.BusinessLogic.Interfaces;

public interface IAccountService
{
    Task<IEnumerable<AccountDto>> GetAll();
}