using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WizardStockFinder.BusinessLogic.Interfaces;

namespace WizardStockFinder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenerController : ControllerBase
    {
        private readonly IScreenerService _screenerService;

        public ScreenerController(IScreenerService screenerService)
        {
            _screenerService = screenerService;
        }

        [Route("", Name = nameof(GetStockData))]
        [HttpGet]
        public async Task<IActionResult> GetStockData()
        {
            var stockData = await _screenerService.GetStockData();

            return Ok(stockData);
        }
    }
}
