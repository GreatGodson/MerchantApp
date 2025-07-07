using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MerchantApp.Domain.Entities;

public class Merchant
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(100)]
    public string BusinessName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public MerchantStatus Status { get; set; } = MerchantStatus.Pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    [JsonIgnore]

    public string Password { get; set; } = string.Empty;

}
