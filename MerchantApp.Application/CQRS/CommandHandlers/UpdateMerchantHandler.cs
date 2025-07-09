using MediatR;
using MerchantApp.Application.Abstractions.Persistence;
using MerchantApp.Application.Abstractions.Services;
using MerchantApp.Application.Common;
using MerchantApp.Application.CQRS.Wrapper;
using MerchantApp.Domain.Entities;

namespace MerchantApp.Application.CQRS.CommandHandlers;
public class UpdateMerchantHandler(
    IMerchantRepository merchantRepository,
    ICountryValidationService countryValidationService
) : IRequestHandler<MerchantUpdateWrapper, ApiResponse<Merchant>>
{
    private readonly IMerchantRepository _merchantRepository = merchantRepository;
    private readonly ICountryValidationService _countryValidationService = countryValidationService;

    public async Task<ApiResponse<Merchant>> Handle(MerchantUpdateWrapper request, CancellationToken cancellationToken)
    {
        var merchant = await _merchantRepository.GetMerchantByIdAsync(request.Id);

        if (merchant is null)
            return ApiResponse<Merchant>.BadRequest("Merchant not found.");

        var data = request.Data;

        if (!string.IsNullOrWhiteSpace(data.BusinessName))
            merchant.BusinessName = data.BusinessName;

        if (!string.IsNullOrWhiteSpace(data.PhoneNumber))
            merchant.PhoneNumber = data.PhoneNumber;

        if (!string.IsNullOrWhiteSpace(data.Country))
        {
            var isValid = await _countryValidationService.IsValidCountryAsync(data.Country, cancellationToken);
            if (!isValid)
                return ApiResponse<Merchant>.BadRequest("Invalid country.");

            merchant.Country = data.Country;
        }

        await _merchantRepository.UpdateMerchantAsync(merchant);

        return ApiResponse<Merchant>.Success(merchant, "Merchant updated successfully.");
    }
}