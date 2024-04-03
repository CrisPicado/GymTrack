using Application.Clients;
using Application.Coaches;
using Application.Exercises;
using Application.Equipments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Routines;
using FluentValidation;
using Domain.Clients;
using Domain.Routines;
using Domain.Coaches;

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
            //mapper
            services.AddAutoMapper(typeof(ClientProfile));
            services.AddAutoMapper(typeof(CoachProfile));
            services.AddAutoMapper(typeof(ExerciseProfile));
            services.AddAutoMapper(typeof(EquipmentsProfile));
            services.AddAutoMapper(typeof(RoutineProfile));
            //FluentValidation
            services.AddScoped<IValidator<CreateClient>,CreateClientValidator>();
            services.AddScoped<IValidator<UpdateClient>, UpdateClientValidator>();
            services.AddScoped<IValidator<CreateCoach>, CreateCoachValidator>();
            services.AddScoped<IValidator<UpdateCoach>, UpdateCoachValidator>();
            services.AddScoped<IValidator<CreateRoutine>,CreateRoutineValidator>();
            services.AddScoped<IValidator<UpdateRoutine>,UpdateRoutineValidator>();

            return services;
        }
    }
}
