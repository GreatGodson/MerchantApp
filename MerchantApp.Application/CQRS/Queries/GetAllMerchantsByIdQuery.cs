using MediatR;
using MerchantApp.Application.Common;
using MerchantApp.Domain.Entities;


namespace MerchantApp.Application.CQRS.Queries;
public class GetMerchantByIdQuery : IRequest<ApiResponse<Merchant>>
{
    public string Id { get; set; } = string.Empty;
}