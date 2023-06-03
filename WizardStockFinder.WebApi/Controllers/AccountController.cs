using Microsoft.AspNetCore.Mvc;
using System.Net;
using WizardStockFinder.BusinessLogic.Interfaces;
using WizardStockFinder.Models.AccountModels;
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

        /// <summary>
        ///     Get account data for logged in account
        /// </summary>
        /// <remarks>
        ///     Get account data for the account that is logged in.
        /// </remarks>
        [Route("", Name = nameof(GetAccounts))]
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var account = await _accountService.GetAll();
            
            return Ok(account);
        }
    }
}
