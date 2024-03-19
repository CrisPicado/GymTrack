﻿using Application.Clients;
using Application.Coaches;
using Application.Equipments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class Injection
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<IEquipmentsService, EquipmentsService>();
            services.AddAutoMapper(typeof(ClientProfile));
            services.AddAutoMapper(typeof(CoachProfile));

            return services;
        }
    }
}
