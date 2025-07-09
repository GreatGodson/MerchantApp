using MerchantApp.Application.Abstractions.Services;
using System.Net.Http;
using System.Text.Json;


namespace MerchantApp.Infrastructure.Services;
public class CountryValidationService(HttpClient httpClient) : ICountryValidationService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<bool> IsValidCountryAsync(string countryName, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{countryName}?fullText=true", cancellationToken);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}