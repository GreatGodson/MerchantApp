using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;


namespace MerchantApp.Domain.Entities;

public class Merchant : IdentityUser
{

    [Required]
    [MaxLength(100)]
    public string BusinessName { get; set; } = string.Empty;

    [Required]
    public MerchantStatus Status { get; set; } = MerchantStatus.Pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    /// <summary>
    /// ignoree this data from the response model
    /// </summary>

    [JsonIgnore] public override string? UserName { get; set; }
    [JsonIgnore] public override string? NormalizedUserName { get; set; }
    [JsonIgnore] public override string? PasswordHash { get; set; }
    [JsonIgnore] public override string? SecurityStamp { get; set; }
    [JsonIgnore] public override bool PhoneNumberConfirmed { get; set; }
    [JsonIgnore] public override bool TwoFactorEnabled { get; set; }
    [JsonIgnore] public override DateTimeOffset? LockoutEnd { get; set; }
    [JsonIgnore] public override bool LockoutEnabled { get; set; }
    [JsonIgnore] public override int AccessFailedCount { get; set; }
    [JsonIgnore] public override string? NormalizedEmail { get; set; }
    [JsonIgnore] public override bool EmailConfirmed { get; set; }
    [JsonIgnore] public override string? ConcurrencyStamp { get; set; }




}