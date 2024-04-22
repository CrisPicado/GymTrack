using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Clients
{
    public class ClientDTO : Entity
    {
        public ClientDTO()
        {
            
        }

        public ClientDTO(int id, string fullName) 
        {
            Id = id;
            FullName = fullName;

        }

        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
