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
        private readonly ISupportResistanceIndicator _supportResistanceIndicator;

        public ScreenerController(IScreenerService screenerService, ISupportResistanceIndicator supportResistanceIndicator)
        {
            _screenerService = screenerService;
            _supportResistanceIndicator = supportResistanceIndicator;
        }

        [Route("", Name = nameof(GetStockData))]
        [HttpGet]
        public async Task<IActionResult> GetStockData()
        {
            var stockData = await _screenerService.GetStockData();

            return Ok(stockData);
        }

        [Route("supportResistanceIndicator", Name = nameof(GetSupportResistanceStockData))]
        [HttpGet]
        public async Task<IActionResult> GetSupportResistanceStockData()
        {
            var stockData = await _supportResistanceIndicator.CalculateSupportResistance();

            return Ok(stockData);
        }
    }
}
