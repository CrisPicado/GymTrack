using Domain.Clients;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients
{
    public interface IClientContract
    {
        Task<List<ClientDTO>> List();
        Task<Result> Create(CreateClient createClient);
        Task<Result> Update(UpdateClient updateClient);
        Task<Result> Delete(int id);
        Task<Result<Client>> Get(int id);
    }
}
