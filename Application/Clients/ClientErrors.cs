using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Application.Clients
{
    public class ClientErrors
    {
        public static Error NotFound(int id) =>
            new Error("Clients.NOT_FOUND", $"The client with id {id} was not found.");

        public static Error NotFound() =>
            new Error("Clients.NOT_FOUND", $"The client was not found.");
    }
}
