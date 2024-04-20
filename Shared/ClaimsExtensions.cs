using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class ClaimsExtensions
    {
        public static string GetClaim(this IIdentity identity, string claimType)
        {
            return ((ClaimsIdentity)identity).Claims.FirstOrDefault(s=>s.Type == claimType)?.Value;
        }

    }
}
