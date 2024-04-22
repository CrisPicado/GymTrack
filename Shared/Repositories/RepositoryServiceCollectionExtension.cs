using Microsoft.Extensions.DependencyInjection;
using Shared.Domain;

namespace Shared.Repositories
{
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepository<TEntity, TContract, TRepository>
            (this IServiceCollection services)
            where TEntity : Entity
            where TContract : class, IRepositoryBase<TEntity>
            where TRepository : class, TContract
        {
            services.AddScoped<TContract, TRepository>();

            return services;
        }
    }
}
