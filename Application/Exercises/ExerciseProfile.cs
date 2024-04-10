using AutoMapper;
using Domain.Clients;
using Domain.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exercises
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<CreateExercise, Exercise>();

            CreateMap<UpdateExercise, Exercise>()
            .ForMember(destination => destination.Id, source => source.Ignore());

            CreateMap<Exercise, UpdateExercise>()
                .ForMember(dest => dest.EquipmentId, opt => opt.MapFrom(src => src.Equipment.Id));

            CreateMap<Exercise, ExerciseDTO>()
                .ConstructUsing(source =>
                new ExerciseDTO(source.Id, source.Name, source.TargetZone, source.Sets, source.Repeats, source.Weight, source.EquipmentId, source.Equipment));

        }
    }
}
