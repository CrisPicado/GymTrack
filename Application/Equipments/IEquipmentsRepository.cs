using Shared.Repositories;
using Domain.Coaches;
using Domain.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Equipments
{
    public interface IEquipmentsRepository : IRepositoryBase<Equipment>
    {
    }
}
