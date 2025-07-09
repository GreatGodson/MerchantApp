
namespace MerchantApp.Application.Abstractions.Services;
public interface ICountryValidationService

{
    Task<bool> IsValidCountryAsync(string countryName, CancellationToken cancellationToken = default);
}