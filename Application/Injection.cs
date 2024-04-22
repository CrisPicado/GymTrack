using Application.Clients;
using Application.Coaches;
using Application.Exercises;
using Application.Equipments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Routines;
using FluentValidation;
using Domain.Clients;
using Domain.Routines;
using Domain.Coaches;
using Domain.Equipments;
using Domain.Exercises;
using Application.Identity;

namespace Application
{
    public static class Injection
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            //inyección de dependencias
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IEquipmentsService, EquipmentsService>();
            services.AddScoped<IRoutineService, RoutineService>();
            services.AddScoped<IIdentityService, IdentityService>();

            //mapper
            services.AddAutoMapper(typeof(ClientProfile));
            services.AddAutoMapper(typeof(CoachProfile));
            services.AddAutoMapper(typeof(ExerciseProfile));
            services.AddAutoMapper(typeof(EquipmentsProfile));
            services.AddAutoMapper(typeof(RoutineProfile));

            //ValidationAssemblies
            services.AddValidatorsFromAssemblies(new[] {typeof(CreateClientValidator).Assembly});
            services.AddValidatorsFromAssemblies(new[] { typeof(CreateCoachValidator).Assembly });
            services.AddValidatorsFromAssemblies(new[] { typeof(CreateEquipmentsValidator).Assembly });
            services.AddValidatorsFromAssemblies(new[] { typeof(CreateExerciseValidator).Assembly });
            services.AddValidatorsFromAssemblies(new[] { typeof(CreateRoutineValidator).Assembly });


            return services;
        }
    }
}
