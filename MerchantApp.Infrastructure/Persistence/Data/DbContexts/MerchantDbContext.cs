using MerchantApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MerchantApp.Infrastructure.Persistence.Data.DbContexts;
public class MerchantDbContext(DbContextOptions<MerchantDbContext> options) : IdentityDbContext<Merchant>(options)
{
    public DbSet<Merchant> Merchants => Set<Merchant>();
}


