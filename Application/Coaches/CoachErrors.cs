using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Coaches
{
    public static class CoachErrors
    {
        public static Error NotFound(int id) =>
            new Error("Coach.NOT_FOUND", $"The Coach with id {id} was not found.");
        public static Error NotFound() =>
            new Error("Coach.NOT_FOUND", $"The Coach was not found.");
        public static Error NotCreated() =>
            new Error("Coach.NOT_CREATED", $"The Coach was not created.");

        public static Error NotUpdated() =>
            new Error("Coach.NOT_UPDATED", $"The Coach was not updated.");

        public static Error NotDeleted() =>
            new Error("Coach.NOT_DELETED", $"The Coach was not deleted.");
    }
}
