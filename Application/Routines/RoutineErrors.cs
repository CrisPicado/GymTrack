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

        public static Error NotCreated() =>
            new Error("Routines.NOT_CREATED", $"The routine was not created.");

        public static Error NotUpdated() =>
            new Error("Routines.NOT_UPDATED", $"The routine was not updated.");

        public static Error NotDeleted() =>
            new Error("Routines.NOT_DELETED", $"The routine was not deleted.");
    }
}
