using Domain.Routines;
using Shared;

namespace Application.Routines
{
    public interface IRoutineClient
    {
        Task<List<RoutineDTO>> List();
        Task<Result> Create(CreateRoutine createClient);
        Task<Result> Update(UpdateRoutine updateClient);
        Task<Result> Delete(int id);
        Task<Result<Routine>> Get(int id);
        Task<List<RoutineDTO>> GetRoutinesForClient(string email);
    }
}
