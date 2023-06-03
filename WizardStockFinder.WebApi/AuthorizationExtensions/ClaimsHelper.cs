using System.Net;
using System.Security.Claims;
using WizardStockFinder.DataAccess;
using WizardStockFinder.Models.AccountModels;

namespace WizardStockFinder.WebApi.AuthorizationExtensions
{
    public class ClaimsHelper
    {
        private readonly ClaimsPrincipal _principal;
        private readonly HttpRequest _request;
        public ClaimsHelper(ClaimsPrincipal principal, HttpRequest request = null)
        {
            _principal = principal;
            _request = request;
        }

        public int AccountId => Convert.ToInt32(FindClaim("AccountId").Value);
        public IPAddress IpAddress => _request.HttpContext.Connection.RemoteIpAddress;

        public DateTime Expires
        {
            get
            {
                var timestamp = Convert.ToDouble(FindClaim("exp").Value);
                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                return date.AddSeconds(timestamp);
            }
        }

        public Enums.AccountRole Role
        {
            get
            {
                var roleString = FindClaim("Role").Value;
                Enum.TryParse(roleString, out Enums.AccountRole role);
                return role;
            }
        }

        public AccountAuthDto AccountAuthDto =>
            new()
            {
                AccountId = AccountId,
                Role = Role,
                IpAddress = IpAddress
            };

        private ClaimsPrincipal Identity => _principal ?? null;

        private ICollection<TEnum> ConvertEnumCollection<TEnum>(string claimName) where TEnum : struct
        {
            var claim = FindClaim(claimName);
            return claim != null
                ? claim.Value.Split(",").Where(x => Enum.IsDefined(typeof(TEnum), x)).Select(Enum.Parse<TEnum>).ToList()
                : new List<TEnum>();
        }

        private Claim FindClaim(string claimType)
        {
            return Identity?.Claims.FirstOrDefault(c => c.Type == claimType);
        }
    }
}
