using Domain.Coaches;
using Domain.Equipments;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Equipments
{
    public interface IEquipmentsService
    {
        Result<IList<Equipment>> List();
        Result<Equipment> Get(int id);

        Result Create(CreateEquiments createEquiments);
        Result Update(UpdateEquipments updateEquiments);
        Result Delete(int id);
    }
}
