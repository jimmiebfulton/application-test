namespace CustomerService.APIs.Dtos;

public class Customer
{
    public DateTime CreatedAt { get; set; }

    public string FirstName { get; set; }

    public string Id { get; set; }

    public string LastName { get; set; }

    public string? MiddleName { get; set; }

    public DateTime UpdatedAt { get; set; }
}
