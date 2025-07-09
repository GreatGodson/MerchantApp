using MerchantApp.Domain.Entities;

namespace MerchantApp.Application.Abstractions.Persistence;
public interface IMerchantRepository
{
    Task<List<Merchant>> GetAllMerchantsAsync(CancellationToken cancellationToken);
    Task<Merchant> CreateMerchantsAsync(Merchant merchant, string password);
    Task<Merchant?> GetMerchantByIdAsync(string merchantId);
    Task<bool> DeleteMerchantByIdAsync(Merchant merchant);
    Task UpdateMerchantAsync(Merchant merchant);


}