using Application.Identity;
using Domain.Authorization;
using Infrastructure.Contexts;
using Shared.Repositories;

namespace Infrastructure.Identity
{
    public class PermissionsRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionsRepository(ApplicationIdentityDbContext context)
            : base(context)
        {
        }

        public bool HasAccess(string email, string controller, string action)
        {
            IQueryable<Permission> query = _entities;
            int count = query.Where(w =>
                w.Email == email &&
                w.Controller == controller &&
                w.Action == action)
            .Select(s => 1)
            .Count();

            return count > 0;
        }
    }
}
