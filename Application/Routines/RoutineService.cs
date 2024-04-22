using Application.Exercises;
using AutoMapper;
using Domain.Exercises;
using Domain.Routines;
using Shared;

namespace Application.Routines
{
    public class RoutineService : IRoutineService
    {
        private readonly IRoutineRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _exerciseRepository;


        public RoutineService(IRoutineRepository repository, IMapper mapper, IExerciseRepository exerciseRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
        }

        public Result<Routine> Get(int id)
        {
            var routine = _repository.GetAllIncluding()
            .FirstOrDefault(r => r.Id == id);

            if (routine is null)
            {
                return Result.Failure<Routine>(RoutineErrors.NotFound());
            }

            return Result.Success(routine);
        }

        public Result<IList<Routine>> List()
        {
            var routines = _repository.GetAllIncluding().ToList();

            return Result.Success<IList<Routine>>(routines);
        }

        public Result<IList<Routine>> GetRoutinesForClientAsync(string Email)
        {
            var routines = _repository.GetAllIncluding().Where(r => r.Client.Email == Email).ToList();
            return Result.Success<IList<Routine>>(routines);
        }

        public List<Exercise> GetExercisesByIds(List<int> exerciseIds)
        {
            return _exerciseRepository.GetAll().Where(e => exerciseIds.Contains(e.Id)).ToList();
        }


        public Result Create(CreateRoutine createRoutine)
        {
            var routine = _mapper.Map<CreateRoutine, Routine>(createRoutine);
            var exercises = GetExercisesByIds(createRoutine.ExerciseIds);

            routine.Exercises = exercises;

            _repository.Insert(routine);
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

            var routine = result.Value;
            _repository.Delete(routine);
            _repository.Save();
            return Result.Success();
        }

        public Result Update(UpdateRoutine updateRoutine)
        {
            var result = Get(updateRoutine.Id);

            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var routine = result.Value;
            _mapper.Map<UpdateRoutine, Routine>(updateRoutine, routine);
            var exercises = GetExercisesByIds(updateRoutine.ExerciseIds);
            routine.Exercises = exercises;

            _repository.Update(routine);
            _repository.Save();
            return Result.Success();
        }



    }
}
