using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.BusinessLogic.Interfaces;
using WizardStockFinder.DataAccess.Interfaces;
using WizardStockFinder.DataAccess.Models;
using WizardStockFinder.Models.AccountModels;

namespace WizardStockFinder.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<AccountDto>> GetAll()
        {
            var accounts = await _accountRepository.GetAll();
         
            return accounts.Select(AccountDto.FromModel);
        }
    }
}
