using Application.Clients;
using Application.Coaches;
using Application.Contexts;
using Application.Exercises;
using Application.Equipments;
using Domain.Clients;
using Domain.Coaches;
using Domain.Exercises;
using Domain.Equipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Clients;
using Persistence.Coaches;
using Persistence.Contexts;
using Persistence.Exercises;
using Persistence.Equipments;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Routines;
using Application.Routines;
using Persistence.Routines;

namespace Persistence
{
    public static class Injection
    {
        public static IServiceCollection AddPersistenceServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>
                (options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("Default"));
                });

            services.AddScoped<IApplicationDbContext>
                (options => options.GetService<ApplicationDbContext>());


            services.AddRepository<Client, IClientRepository, ClientRepository>();
            services.AddRepository<Coach, ICoachRepository, CoachRepository>();
            services.AddRepository<Exercise, IExerciseRepository, ExerciseRepository>();
            services.AddRepository<Equipment, IEquipmentsRepository, EquipmentsRepository>();
            services.AddRepository<Routine, IRoutineRepository, RoutineRepository>();


            return services;
        }
    }
}
