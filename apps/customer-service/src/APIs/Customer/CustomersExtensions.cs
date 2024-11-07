using CustomerService.APIs.Dtos;
using CustomerService.Infrastructure.Models;

namespace CustomerService.APIs.Extensions;

public static class CustomersExtensions
{
    public static Customer ToDto(this CustomerDbModel model)
    {
        return new Customer
        {
            CreatedAt = model.CreatedAt,
            FirstName = model.FirstName,
            Id = model.Id,
            LastName = model.LastName,
            MiddleName = model.MiddleName,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CustomerDbModel ToModel(
        this CustomerUpdateInput updateDto,
        CustomerWhereUniqueInput uniqueId
    )
    {
        var customer = new CustomerDbModel { Id = uniqueId.Id, MiddleName = updateDto.MiddleName };

        if (updateDto.CreatedAt != null)
        {
            customer.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.FirstName != null)
        {
            customer.FirstName = updateDto.FirstName;
        }
        if (updateDto.LastName != null)
        {
            customer.LastName = updateDto.LastName;
        }
        if (updateDto.UpdatedAt != null)
        {
            customer.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return customer;
    }
}
