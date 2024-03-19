using Application.Clients;
using AutoMapper;
using Domain.Coaches;
using Shared;


namespace Application.Coaches
{
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _repository;
        private readonly IMapper _mapper;

        public CoachService(ICoachRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Result<IList<Coach>> List()
        {
            return Result.Success<IList<Coach>>(_repository.GetAll());
        }

        public Result<Coach> Get(int id)
        {
            var coach = _repository.Get(c => c.Id == id);

            if (coach == null)
            {
                return Result.Failure<Coach>(CoachErrors.NotFound());
            }

            return Result.Success(coach);
        }

        public Result Create(CreateCoach createCoach)
        {
            var coach = _mapper.Map<CreateCoach, Coach>(createCoach);
            _repository.Insert(Coach.Create(0, coach));
            _repository.Save();
            return Result.Success();
        }

        public Result Update(UpdateCoach updateCoach)
        {
            var result = Get(updateCoach.Id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var coach = result.Value;
            _mapper.Map<UpdateCoach, Coach>(updateCoach, coach);
            _repository.Update(coach);
            _repository.Save();
            return Result.Success();
        }

        public Result Delete(int id)
        {
            var result = Get(id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var coach = result.Value;
            _repository.Delete(coach);
            _repository.Save();
            return Result.Success();
        }

    }
}
