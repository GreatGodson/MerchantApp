using MerchantApp.Application.Abstractions.Persistence;
using MerchantApp.Domain.Entities;
using MerchantApp.Infrastructure.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace MerchantApp.Infrastructure.Persistence.Repositories;

public class MerchantRepository(MerchantDbContext dbContext) : IMerchantRepository
{
    private readonly MerchantDbContext _dbContext = dbContext;

    public async Task<List<Merchant>> GetAllMerchantsAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Merchants.ToListAsync(cancellationToken);
    }



    public async Task<Merchant> CreateMerchantsAsync(Merchant merchant, CancellationToken cancellationToken)
    {
        await _dbContext.Merchants.AddAsync(merchant, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return merchant;
    }
}