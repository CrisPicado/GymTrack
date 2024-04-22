using Domain.Authorization;
using Shared.Repositories;


namespace Application.Identity
{
    public interface IPermissionRepository : IRepositoryBase<Permission>
    {
        bool HasAccess(string email, string controller, string action);
    }
}
