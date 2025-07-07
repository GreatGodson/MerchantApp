using MerchantApp.Application.Abstractions.Persistence;
using MerchantApp.Infrastructure.Persistence.Data.DbContexts;
using MerchantApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MerchantApp.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {

        services.AddDbContext<MerchantDbContext>(options =>
              options.UseInMemoryDatabase("MerchantInMemoryDb"));
        services.AddScoped<IMerchantRepository, MerchantRepository>();

        return services;
    }
}