using Domain.Exercises;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exercises
{
    public interface IExerciseService
    {
        Result<IList<Exercise>> List();

        Result<Exercise> Get(int id);

        Result Create(CreateExercise createExercise);

        Result Update(UpdateExercise updateExercise);

        Result Delete(int id);
    }
}
