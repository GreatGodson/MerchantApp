using MediatR;
using MerchantApp.Application.Common;
using MerchantApp.Domain.Entities;

namespace MerchantApp.Application.CQRS.Commands;

public class UpdateMerchantCommand : IRequest<ApiResponse<Merchant>>
{

    public string? BusinessName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Country { get; set; }
    public string? MerchantStatus { get; set; }

}