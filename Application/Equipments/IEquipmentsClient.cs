using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Clients;
using Domain.Equipments;
using Shared;

namespace Application.Equipments
{
    public interface IEquipmentsClient
    {

        Task<List<EquipmentDTO>> List();
        Task<Result> Create(CreateEquipments createEquipments);
        Task<Result> Update(UpdateEquipments updateEquipments);
        Task<Result> Delete(int id);
        Task<Result<Equipment>> Get(int id);
    }
}
