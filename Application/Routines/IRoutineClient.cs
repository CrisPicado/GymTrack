using Domain.Routines;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Routines
{
    public interface IRoutineClient
    {
        Task<List<RoutineDTO>> List();
        Task<Result> Create(CreateRoutine createClient);
        Task<Result> Update(UpdateRoutine updateClient);
        Task<Result> Delete(int id);
        Task<Result<Routine>> Get(int id);
    }
}
