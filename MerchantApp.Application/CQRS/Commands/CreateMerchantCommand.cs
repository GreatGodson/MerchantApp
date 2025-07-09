using MediatR;
using MerchantApp.Application.Common;
using MerchantApp.Domain.Entities;

namespace MerchantApp.Application.CQRS.Commands;
public class CreateMerchantCommand : IRequest<ApiResponse<Merchant>>
{


    public string BusinessName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;


    public string PhoneNumber { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}