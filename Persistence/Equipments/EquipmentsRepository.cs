using Application.Equipments;
using Domain.Equipments;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence.Equipments
{
    public class EquipmentsRepository : RepositoryBase<Equipment>, IEquipmentsRepository
    {
        public EquipmentsRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
