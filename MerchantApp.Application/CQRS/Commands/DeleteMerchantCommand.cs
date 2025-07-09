using MediatR;
using MerchantApp.Application.Common;

namespace MerchantApp.Application.CQRS.Commands;

public class DeleteMerchantCommand(string merchantId) : IRequest<ApiResponse<string>>
{
    public string MerchantId { get; set; } = merchantId;
}