using Microsoft.AspNetCore.Identity;

namespace MerchantApp.Domain.Entities;
public class ApplicationUser : IdentityUser
    {
        public required string FullName { get; set; }
        // public string? RefreshToken { get; set; }
        // public DateTime RefreshTokenExpiryTime { get; set; }
    }