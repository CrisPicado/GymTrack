using Application.Clients;
using Application.Repositories;
using Domain.Clients;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Clients
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {

        public ClientRepository(ApplicationDbContext context) 
            : base(context)
        { }

    }
}
