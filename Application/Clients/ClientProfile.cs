﻿using AutoMapper;
using Domain.Clients;
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
            CreateMap<CreateClient, Client>()
                .ForMember(destination => destination.PhoneNumber,
                    source => source.MapFrom(s=>s.PhoneNumber));

            CreateMap<UpdateClient, Client>()
            .ForMember(destination => destination.Id, source => source.Ignore());

        }
    }
}
