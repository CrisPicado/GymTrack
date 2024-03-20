using Application.Routines;
using Domain.Routines;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Routines
{
    public class RoutineRepository : RepositoryBase<Routine>, IRoutineRepository
    {
        public RoutineRepository(ApplicationDbContext context)
            : base(context)
        { }

        public IQueryable<Routine> GetAllIncluding()
        {
            return _context.Routines
                .Include(r => r.Coach)
                .Include(r => r.Client)
                .Include(r => r.Exercises);
        }
    }
}
