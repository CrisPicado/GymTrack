using Application.Exercises;
using AutoMapper;
using Domain.Exercises;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _repository;
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Result<IList<Exercise>> List()
        {
            return Result.Success<IList<Exercise>>(_repository.GetAllIncluding().ToList());
        }

        public Result<Exercise> Get(int id)
        {
            var Exercise = _repository.GetAllIncluding()
                .FirstOrDefault(c => c.Id == id);

            if (Exercise is null)
            {
                return Result.Failure<Exercise>(ExerciseErrors.NotFound());
            }
            return Result.Success(Exercise);

        }

        public Result Create(CreateExercise createExercise)
        {
            var Exercise = _mapper.Map<CreateExercise, Exercise>(createExercise);
            _repository.Insert(Exercise.Create(0, Exercise));
            _repository.Save();
            return Result.Success();
        }

        public Result Update(UpdateExercise updateExercise)
        {
            var result = Get(updateExercise.Id);

            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var Exercise = result.Value;
            _mapper.Map<UpdateExercise, Exercise>(updateExercise, Exercise);
            _repository.Update(Exercise);
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

            var Exercise = result.Value;
            _repository.Delete(Exercise);
            _repository.Save();
            return Result.Success();
        }
    }
}
