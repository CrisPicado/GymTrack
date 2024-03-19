using AutoMapper;
using Domain.Clients;
using Domain.Coaches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients
{
    public class ClientProfile : Profile
    {
        public ClientProfile() 
        {
            CreateMap<CreateClient, Coach>()
                .ForMember(destination => destination.PhoneNumber,
                    source => source.MapFrom(s=>s.PhoneNumber));

            CreateMap<UpdateClient, Client>()
            .ForMember(destination => destination.Id, source => source.Ignore());

        }
    }
}
