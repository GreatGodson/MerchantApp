using MediatR;
using MerchantApp.Application.Abstractions.Persistence;
using MerchantApp.Application.Common;
using MerchantApp.Application.CQRS.Queries;
using MerchantApp.Domain.Entities;


namespace MerchantApp.Application.CQRS.QueryHandler;
public class GetMerchantByIdQueryHandler(IMerchantRepository merchantRepository) : IRequestHandler<GetMerchantByIdQuery, ApiResponse<Merchant>>
{
    private readonly IMerchantRepository _merchantRepository = merchantRepository;

    public async Task<ApiResponse<Merchant>> Handle(GetMerchantByIdQuery request, CancellationToken cancellationToken)
    {

        Merchant? merchant = await _merchantRepository.GetMerchantByIdAsync(request.Id);

        if (merchant is null)
        {
            return ApiResponse<Merchant>.NotFound("Merchant not found");
        }
        return ApiResponse<Merchant>.Success(merchant);

    }


}