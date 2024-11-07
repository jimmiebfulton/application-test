using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerService.Infrastructure.Models;

[Table("Customers")]
public class CustomerDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    [StringLength(1000)]
    public string FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    [StringLength(1000)]
    public string LastName { get; set; }

    [StringLength(1000)]
    public string? MiddleName { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
