using Application.Identity;
using Domain.Authorization;
using Infrastructure.Contexts;
using Infrastructure.Identity;
using Infrastructure.Policy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repositories;


namespace Infrastructure
{
    public static class Injection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true; 
            }).AddEntityFrameworkStores<ApplicationIdentityDbContext>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            });

            services.AddScoped<IAuthorizationHandler, PolicyHandler>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddRepository<Permission, IPermissionRepository, PermissionsRepository>();

            return services;
        }
    }
}
