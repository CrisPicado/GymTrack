using Application.Identity;
using Microsoft.AspNetCore.Authorization;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Policy
{
    public class PolicyHandler : AuthorizationHandler<PolicyRequirement>, IAuthorizationHandler
    {
        private readonly IAccountService _accountService;

        public PolicyHandler(IAccountService accountService) 
        {
            _accountService = accountService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PolicyRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Fail();
            }
            else
            {
                var email = context.User.Identity.GetClaim(ClaimTypes.Email);
                var hasAccess = false;
                foreach (var permission in requirement.Permissions) 
                {
                    hasAccess = hasAccess 
                        || _accountService.HasAccess
                            (email, permission.Controller, permission.Action).IsSuccess;

                    if (hasAccess) 
                    {
                        context.Succeed(requirement);
                        break;
                    }
                }

                if (!hasAccess) 
                {
                    context.Fail();
                }
            }

            return Task.CompletedTask;
        }
    }
}
