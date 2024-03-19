using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Application.Exercises
{
    public class ExerciseErrors
    {
        public static Error NotFound(int id) =>
            new Error("Exercises.NOT_FOUND", $"The exercise with id {id} was not found.");

        public static Error NotFound() =>
            new Error("Exercises.NOT_FOUND", $"The exercise was not found.");
    }
}
