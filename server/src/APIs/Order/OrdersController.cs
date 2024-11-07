using Microsoft.AspNetCore.Mvc;

namespace OrderService.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}
