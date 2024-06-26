﻿using AutoMapper;
using Domain.Clients;
using Domain.Coaches;


namespace Application.Coaches
{
    public class CoachProfile : Profile
    {
        public CoachProfile() 
        {
            CreateMap<CreateCoach, Coach>()
                .ForMember(destination => destination.PhoneNumber,
                        source => source.MapFrom(s => s.PhoneNumber));

            CreateMap<UpdateCoach, Coach>()
                .ForMember(destination => destination.Id, source => source.Ignore());

            CreateMap<Coach, UpdateCoach>();

            CreateMap<Coach, CoachDTO>()
                .ConstructUsing(source =>
                new CoachDTO(source.Id, string.Concat(source.FirstName, " ", source.LastName)));

        }
    }
}
