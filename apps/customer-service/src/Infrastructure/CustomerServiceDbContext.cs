using CustomerService.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Infrastructure;

public class CustomerServiceDbContext : IdentityDbContext<IdentityUser>
{
    public CustomerServiceDbContext(DbContextOptions<CustomerServiceDbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<AddressDbModel> Addresses { get; set; }
}
