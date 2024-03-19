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
       public static Error NotFound() =>
        new Error("Coach.NOT_FOUND", $"The Coach was not found.");

    }
}
