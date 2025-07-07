using MediatR;
using MerchantApp.Application.Common;
using MerchantApp.Domain.Entities;


namespace MerchantApp.Application.CQRS.Queries;
public class GetAllMerchantsQuery : IRequest<ApiResponse<List<Merchant>>> { }