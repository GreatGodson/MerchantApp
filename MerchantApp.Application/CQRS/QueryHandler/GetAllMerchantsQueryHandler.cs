using MediatR;
using MerchantApp.Application.Abstractions.Persistence;
using MerchantApp.Application.Common;
using MerchantApp.Application.CQRS.Queries;
using MerchantApp.Domain.Entities;


namespace MerchantApp.Application.CQRS.QueryHandler;
public class GetAllMerchantsQueryHandler(IMerchantRepository merchantRepository) : IRequestHandler<GetAllMerchantsQuery, ApiResponse<List<Merchant>>>
{
    private readonly IMerchantRepository _merchantRepository = merchantRepository;

    public async Task<ApiResponse<List<Merchant>>> Handle(GetAllMerchantsQuery request, CancellationToken cancellationToken)
    {

        var merchants = await _merchantRepository.GetAllMerchantsAsync(cancellationToken);
        return ApiResponse<List<Merchant>>.Success(merchants);

    }

    
}