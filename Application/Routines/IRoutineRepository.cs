using Shared.Repositories;
using Domain.Routines;

namespace Application.Routines
{
    public interface IRoutineRepository : IRepositoryBase<Routine>
    {
        IQueryable<Routine> GetAllIncluding();
    }
}
