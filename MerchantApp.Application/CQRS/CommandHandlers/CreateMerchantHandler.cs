using MediatR;
using MerchantApp.Application.Abstractions.Persistence;
using MerchantApp.Application.Common;
using MerchantApp.Application.CQRS.Commands;
using MerchantApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace MerchantApp.Application.CQRS.CommandHandlers;
public class CreateMerchantHandler(IMerchantRepository merchantRepository, UserManager<Merchant> userManager) : IRequestHandler<CreateMerchantCommand, ApiResponse<Merchant>>
{

    private readonly IMerchantRepository _merchantRepository = merchantRepository;
    private readonly UserManager<Merchant> _userManager = userManager;


    public async Task<ApiResponse<Merchant>> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
    {


        string email = request.Email.Trim().ToLower();

        // Check if user already exists
        Merchant? existingMerchant = await _userManager.FindByEmailAsync(email);

        if (existingMerchant != null)
        {
            return ApiResponse<Merchant>.BadRequest("User with this email already exists.");
        }

        Merchant merchant = new()
        {
            BusinessName = request.BusinessName,
            Email = email,
            UserName = email,
            PhoneNumber = request.PhoneNumber,
            PasswordHash = request.Password,

        };


        Merchant result = await _merchantRepository.CreateMerchantsAsync(merchant, request.Password);

        return ApiResponse<Merchant>.Success(result, "Merchant created successfully", 201);
    }
}