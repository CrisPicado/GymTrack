using Domain.Coaches;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Coaches
{
    public interface ICoachService
    {
        Result<IList<Coach>> List();
        Result<Coach> Get(int id);

        Result Create(CreateCoach createCoach);
        Result Update(UpdateCoach updateCoach);
        Result Delete(int id);
    }
}
