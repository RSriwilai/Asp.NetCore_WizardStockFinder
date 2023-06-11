using Microsoft.AspNetCore.Mvc;
using System.Net;
using WizardStockFinder.BusinessLogic.Interfaces;
using WizardStockFinder.DataAccess.Models;
using WizardStockFinder.Models.AccountModels;
using WizardStockFinder.Models.SubscriptionModels;
using WizardStockFinder.WebApi.AuthorizationExtensions;

namespace WizardStockFinder.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private ClaimsHelper ClaimsHelper => new ClaimsHelper(User, Request);
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [Route("", Name = nameof(CreateSubscription))]
        [HttpPost]
        public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionModel newSubscription)
        {
            return Ok(await _subscriptionService.CreateSubscription(newSubscription));
        }

    }
}
