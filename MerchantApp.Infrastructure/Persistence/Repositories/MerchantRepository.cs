using MerchantApp.Application.Abstractions.Persistence;
using MerchantApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace MerchantApp.Infrastructure.Persistence.Repositories;

public class MerchantRepository(UserManager<Merchant> userManager) : IMerchantRepository
{

    private readonly UserManager<Merchant> _userManager = userManager;

    public async Task<List<Merchant>> GetAllMerchantsAsync(CancellationToken cancellationToken)
    {
        return await _userManager.Users.ToListAsync(cancellationToken);
    }

    public async Task<Merchant> CreateMerchantsAsync(Merchant merchant, string password)
    {
        await _userManager.CreateAsync(merchant, password);
        return merchant;
    }

    public async Task<Merchant?> GetMerchantByIdAsync(string merchantId)
    {
        return await _userManager.Users
            .FirstOrDefaultAsync(m => m.Id == merchantId);
    }

    public async Task<bool> DeleteMerchantByIdAsync(Merchant merchant)
    {
        var result = await _userManager.DeleteAsync(merchant);
        return result.Succeeded;
    }

    public async Task UpdateMerchantAsync(Merchant merchant)
    {
        var result = await _userManager.UpdateAsync(merchant);

        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"Failed to update merchant: {errors}");
        }
    }
}