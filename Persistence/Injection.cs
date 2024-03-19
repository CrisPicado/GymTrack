using Application.Clients;
using Application.Coaches;
using Application.Contexts;
using Domain.Clients;
using Domain.Coaches;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Clients;
using Persistence.Coaches;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            

            return services;
        }
    }
}
