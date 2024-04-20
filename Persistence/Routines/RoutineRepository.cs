using Application.Routines;
using Domain.Routines;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Shared.Repositories;

namespace Persistence.Routines
{
    public class RoutineRepository : RepositoryBase<Routine>, IRoutineRepository
    {
        public RoutineRepository(ApplicationDbContext context)
            : base(context)
        { }

        public IQueryable<Routine> GetAllIncluding()
        {
            return _context.Set<Routine>()
                .Include(r => r.Coach)
                .Include(r => r.Client)
                .Include(r => r.Exercises)
                .ThenInclude(e=> e.Equipment);
        }
    }
}
