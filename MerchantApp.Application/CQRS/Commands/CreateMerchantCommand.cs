using MediatR;
using MerchantApp.Application.Common;
using MerchantApp.Domain.Entities;

namespace MerchantApp.Application.CQRS.Commands;
public class CreateMerchantCommand : IRequest<ApiResponse<Merchant>>
{
    public Guid Id { get; set; } = Guid.NewGuid();


    public string BusinessName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

  
    public string PhoneNumber { get; set; } = string.Empty;


    public MerchantStatus Status { get; set; } = MerchantStatus.Pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public string Password { get; set; } = string.Empty;
}