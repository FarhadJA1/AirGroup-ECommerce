using B.Repository.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace B.Repository;
public static class DependencyInjection
{
    public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        return services;
    }
}
