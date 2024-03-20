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

        }

    }
}
