using Microsoft.AspNetCore.Mvc;

namespace CustomerService.APIs;

[ApiController()]
public class AddressesController : AddressesControllerBase
{
    public AddressesController(IAddressesService service)
        : base(service) { }
}
