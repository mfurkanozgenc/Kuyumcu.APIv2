using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Kuyumcu.API.Application.Helper
{
    public class Helper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Helper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetBranchId()
        {
            var claims = (_httpContextAccessor?.HttpContext?.User?.Identity as ClaimsIdentity)?.Claims ?? Enumerable.Empty<Claim>();
            if (claims.Any())
            {
                var branchClaim = claims.FirstOrDefault(x => x.Type == "Branch");
                if (branchClaim is not null)
                {
                    return Guid.Parse(branchClaim.Value);
                }
            }
            return Guid.Empty;
        }

    }
}
