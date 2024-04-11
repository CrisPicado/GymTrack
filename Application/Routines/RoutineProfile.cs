using AutoMapper;
using Domain.Exercises;
using Domain.Routines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Routines
{
    public class RoutineProfile : Profile
    {
        public RoutineProfile()
        {
            CreateMap<CreateRoutine, Routine>();

            CreateMap<UpdateRoutine, Routine>()
            .ForMember(destination => destination.Id, source => source.Ignore());

            CreateMap<Routine, UpdateRoutine>()
                .ForMember(dest => dest.CoachId, opt => opt.MapFrom(src => src.Coach.Id))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Client.Id))
                .ForMember(dest => dest.ExerciseIds, opt => opt.MapFrom(src => src.Exercises.Select(e => e.Id).ToList()));

            CreateMap<Routine, RoutineDTO>()
                .ConstructUsing(source =>
                new RoutineDTO(source.Id, source.Name, source.Description, source.SequenceNumber,
                source.CoachId, source.Coach, source.ClientId, source.Client, source.Exercises));

        }

    }
}
