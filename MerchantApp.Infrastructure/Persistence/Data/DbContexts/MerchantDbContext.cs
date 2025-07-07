using MerchantApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MerchantApp.Infrastructure.Persistence.Data.DbContexts;
public class MerchantDbContext(DbContextOptions<MerchantDbContext> options) : DbContext(options)
{
    public DbSet<Merchant> Merchants => Set<Merchant>();
}


