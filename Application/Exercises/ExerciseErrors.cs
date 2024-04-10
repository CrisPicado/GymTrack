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

        public static Error NotCreated() =>
            new Error("Exercises.NOT_CREATED", $"The exercise was not created.");

        public static Error NotUpdated() =>
            new Error("Exercises.NOT_UPDATED", $"The exercise was not updated.");

        public static Error NotDeleted() =>
            new Error("Exercises.NOT_DELETED", $"The exercise was not deleted.");
    }
}
