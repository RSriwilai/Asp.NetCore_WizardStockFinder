using WizardStockFinder.DataAccess.Models;
using WizardStockFinder.Models.AccountModels;

namespace WizardStockFinder.BusinessLogic.Interfaces;

public interface IAccountService
{
    Task<IEnumerable<AccountDto>> GetAll();
    Task<Account> CreateAccount(Account account);
}