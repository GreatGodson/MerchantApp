using MediatR;
using MerchantApp.Application.Abstractions.Persistence;
using MerchantApp.Application.Common;
using MerchantApp.Application.CQRS.Commands;
using MerchantApp.Domain.Entities;
namespace MerchantApp.Application.CQRS.CommandHandlers;
public class CreateMerchantHandler(IMerchantRepository merchantRepository) : IRequestHandler<CreateMerchantCommand, ApiResponse<Merchant>>
{

    private readonly IMerchantRepository _merchantRepository = merchantRepository;

    public async Task<ApiResponse<Merchant>> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
    {
        var merchant = new Merchant
        {
            Id = Guid.NewGuid(),
            BusinessName = request.BusinessName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            CreatedAt = DateTime.UtcNow
        };


        Merchant result = await _merchantRepository.CreateMerchantsAsync(merchant, cancellationToken);

        return ApiResponse<Merchant>.Success(result, "Merchant created successfully", 201);
    }
}