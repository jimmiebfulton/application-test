using Microsoft.EntityFrameworkCore;

namespace OrderService.Infrastructure;

public class OrderServiceDbContext : DbContext
{
    public OrderServiceDbContext(DbContextOptions<OrderServiceDbContext> options)
        : base(options) { }
}
