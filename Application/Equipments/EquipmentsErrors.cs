using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Equipments
{
    public class EquipmentsErrors
    {

        public static Error NotFound(int id) =>
            new Error("Equipments.NOT_FOUND", $"The equipment with id {id} was not found.");

        public static Error NotFound() =>
            new Error("Equipments.NOT_FOUND", $"The equipment was not found.");

        public static Error NotCreated() =>
            new Error("Equipments.NOT_CREATED", $"The equipment was not created.");

        public static Error NotUpdated() =>
            new Error("Equipments.NOT_UPDATED", $"The equipment was not updated.");

        public static Error NotDeleted() =>
            new Error("Equipments.NOT_DELETED", $"The equipment was not deleted.");
    }
}
