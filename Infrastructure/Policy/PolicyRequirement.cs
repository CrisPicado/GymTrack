using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Policy
{
    public class PolicyRequirement : IAuthorizationRequirement
    {
        private readonly IEnumerable<PolicyPermission> _permissions;

        public PolicyRequirement(IEnumerable<PolicyPermission> permissions)
        {
            _permissions = permissions;
        }

        public IReadOnlyList<PolicyPermission> Permissions
        {
            get { return _permissions.ToList(); }
        }
    }
}
