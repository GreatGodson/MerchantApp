using MerchantApp.Application.Abstractions.Persistence;
using MerchantApp.Domain.Entities;
using MerchantApp.Infrastructure.Persistence.Data.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


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
        var t = await _userManager.CreateAsync(merchant, password);
        Console.WriteLine("t is:", t);

        if (!t.Succeeded)
        {
            var errors = string.Join("; ", t.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"User creation failed: {errors}");
        }
        // await _dbContext.SaveChangesAsync(cancellationToken);
        return merchant;
    }
}