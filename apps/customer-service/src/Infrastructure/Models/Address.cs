using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerService.Core.Enums;

namespace CustomerService.Infrastructure.Models;

[Table("Addresses")]
public class AddressDbModel
{
    [StringLength(256)]
    public string? City { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public StateEnum? State { get; set; }

    [StringLength(1000)]
    public string? Street1 { get; set; }

    [StringLength(1000)]
    public string? Street2 { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
