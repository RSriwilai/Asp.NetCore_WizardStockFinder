using Microsoft.AspNetCore.Mvc;
using WizardStockFinder.BusinessLogic.Interfaces;
using WizardStockFinder.DataAccess.Models;
using WizardStockFinder.WebApi.AuthorizationExtensions;

namespace WizardStockFinder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private ClaimsHelper ClaimsHelper => new ClaimsHelper(User, Request);

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("", Name = nameof(GetAccounts))]
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var account = await _accountService.GetAll();

            return Ok(account);
        }

        [Route("", Name = nameof(CreateAccount))]
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] Account newAccount)
        {
            var account = await _accountService.CreateAccount(newAccount);

            return Ok(account);
        }
    }
}
