using AutoMapper;
using Domain.Coaches;
using Domain.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Equipments
{
    public class EquipmentsProfile : Profile
    {
        public EquipmentsProfile()
        {

            CreateMap<CreateEquipments, Equipment>();

            CreateMap<UpdateEquipments, Equipment>()

                .ForMember(destination => destination.Id, source => source.Ignore());

            CreateMap<Equipment, UpdateEquipments>();

            CreateMap<Equipment, EquipmentDTO>()
               .ConstructUsing(source =>
               new EquipmentDTO(source.Id, source.Name, source.Description));
        }
    }
}
