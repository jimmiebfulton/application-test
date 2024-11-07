using OrderService.Infrastructure;

namespace OrderService.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(OrderServiceDbContext context)
        : base(context) { }
}
