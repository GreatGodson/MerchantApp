using MerchantApp.Application.Abstractions.Persistence;
using MerchantApp.Domain.Entities;
using MerchantApp.Infrastructure.Persistence.Data.DbContexts;
using MerchantApp.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
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


        services.AddIdentity<Merchant, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.SignIn.RequireConfirmedEmail = true;
    })
    .AddEntityFrameworkStores<MerchantDbContext>()
    .AddDefaultTokenProviders();

        return services;
    }
}