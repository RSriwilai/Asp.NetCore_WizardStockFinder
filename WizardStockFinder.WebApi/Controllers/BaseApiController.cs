using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WizardStockFinder.WebApi.AuthorizationExtensions;

namespace WizardStockFinder.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        public ClaimsHelper ClaimsHelper => new ClaimsHelper(User, Request);

        public BaseApiController()
        {
        }

        internal IActionResult OkOrNotFound(object data)
        {
            if (data != null) return Ok(data);
            return NotFound();
        }


        internal IActionResult Forbidden()
        {
            return StatusCode(403,
                "User Role not authorized for this action");
        }
    }
}
