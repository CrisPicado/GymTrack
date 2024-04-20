using Shared.Repositories;
using Domain.Routines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Routines
{
    public interface IRoutineRepository : IRepositoryBase<Routine>
    {
        IQueryable<Routine> GetAllIncluding();
    }
}
