using Domain.Coaches;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Coaches
{
    public interface ICoachClient
    {
        Task<List<CoachDTO>> List();
        Task<Result> Create(CreateCoach createCoach);
        Task<Result> Update(UpdateCoach updateCoach);
        Task<Result> Delete(int id);
        Task<Result<Coach>> Get(int id);
    }
}
