using CustomerService.Core.Enums;

namespace CustomerService.APIs.Dtos;

public class AddressCreateInput
{
    public string? City { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public StateEnum? State { get; set; }

    public string? Street1 { get; set; }

    public string? Street2 { get; set; }

    public DateTime UpdatedAt { get; set; }
}