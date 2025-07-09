using MediatR;
using MerchantApp.Application.Common;
using MerchantApp.Application.CQRS.Commands;
using MerchantApp.Domain.Entities;

namespace MerchantApp.Application.CQRS.Wrapper;
public class MerchantUpdateWrapper : IRequest<ApiResponse<Merchant>>
{
    public string Id { get; }
    public UpdateMerchantCommand Data { get; }

    public MerchantUpdateWrapper(string id, UpdateMerchantCommand data)
    {
        Id = id;
        Data = data;
    }
}