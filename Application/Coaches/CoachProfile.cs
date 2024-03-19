using AutoMapper;
using Domain.Coaches;


namespace Application.Coaches
{
    public class CoachProfile : Profile
    {
        public CoachProfile() 
        {
            CreateMap<UpdateCoach, Coach>()
                .ForMember(destination => destination.Id, source => source.Ignore());
        }
    }
}
