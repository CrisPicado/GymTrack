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
        public static Error NotFound() =>
            new Error("Coach.NOT_FOUND", $"The Coach was not found.");
    }
}
