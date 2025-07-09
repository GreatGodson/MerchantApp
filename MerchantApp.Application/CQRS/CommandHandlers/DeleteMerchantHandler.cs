using MediatR;
using MerchantApp.Application.Abstractions.Persistence;
using MerchantApp.Application.Common;
using MerchantApp.Application.CQRS.Commands;
using MerchantApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MerchantApp.Application.CQRS.CommandHandlers;

public class DeleteMerchantHandler(
    IMerchantRepository merchantRepository,
    UserManager<Merchant> userManager
) : IRequestHandler<DeleteMerchantCommand, ApiResponse<string>>
{
    private readonly IMerchantRepository _merchantRepository = merchantRepository;
    private readonly UserManager<Merchant> _userManager = userManager;

    public async Task<ApiResponse<string>> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the merchant
        Merchant? merchant = await _merchantRepository.GetMerchantByIdAsync(request.MerchantId);

        if (merchant is null)
        {
            return ApiResponse<string>.BadRequest("Merchant not found.");
        }

        // Delete the merchant
        await _merchantRepository.DeleteMerchantByIdAsync(merchant);


        return ApiResponse<string>.Success("Merchant deleted successfully.");
    }
}