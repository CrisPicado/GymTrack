using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Routines
{
    public static class RoutineErrors
    {
        public static Error NotFound(int id) =>
            new Error("Routines.NOT_FOUND", $"The routine with the ID {id} was not found.");

        public static Error NotFound() =>
            new Error("Routines.NOT_FOUND", $"The routine was not found.");
    }
}
