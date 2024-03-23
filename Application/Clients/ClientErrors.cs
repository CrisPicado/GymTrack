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

        public static Error NotCreated() =>
            new Error("Clients.NOT_CREATED", $"The client was not created.");

        public static Error NotUpdated() =>
            new Error("Clients.NOT_UPDATED", $"The client was not updated.");

        public static Error NotDeleted() =>
            new Error("Clients.NOT_DELETED", $"The client was not deleted.");
    }
}
