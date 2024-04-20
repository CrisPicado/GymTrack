using Application.Clients;
using Domain.Clients;
using Persistence.Contexts;
using Shared.Repositories;


namespace Persistence.Clients
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {

        public ClientRepository(ApplicationDbContext context) 
            : base(context)
        { }

    }
}
