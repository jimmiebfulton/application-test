using CustomerService.Infrastructure;

namespace CustomerService.APIs;

public class AddressesService : AddressesServiceBase
{
    public AddressesService(CustomerServiceDbContext context)
        : base(context) { }
}
