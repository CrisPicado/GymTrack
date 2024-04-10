using Domain.Exercises;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exercises
{
    public interface IExerciseClient
    {
        Task<List<ExerciseDTO>> List();
        Task<Result> Create(CreateExercise createExercise);
        Task<Result> Update(UpdateExercise updateExercise);
        Task<Result> Delete(int id);
        Task<Result<Exercise>> Get(int id);
    }
}
