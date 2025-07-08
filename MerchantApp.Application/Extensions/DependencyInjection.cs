using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using MerchantApp.Application.CQRS.Validators.Merchant;
using MerchantApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
namespace MerchantApp.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<CreateMerchantCommandValidator>();




        return services;
    }
}