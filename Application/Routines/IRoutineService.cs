using Domain.Routines;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Routines
{
    public interface IRoutineService
    {
        Result<IList<Routine>> List();

        Result<Routine> Get(int id);

        Result Create(CreateRoutine createRoutine);

        Result Update(UpdateRoutine updateRoutine);

        Result Delete(int id);
    }
}
