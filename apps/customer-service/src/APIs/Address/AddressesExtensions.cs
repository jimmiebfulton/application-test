using CustomerService.APIs.Dtos;
using CustomerService.Infrastructure.Models;

namespace CustomerService.APIs.Extensions;

public static class AddressesExtensions
{
    public static Address ToDto(this AddressDbModel model)
    {
        return new Address
        {
            City = model.City,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            State = model.State,
            Street1 = model.Street1,
            Street2 = model.Street2,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AddressDbModel ToModel(
        this AddressUpdateInput updateDto,
        AddressWhereUniqueInput uniqueId
    )
    {
        var address = new AddressDbModel
        {
            Id = uniqueId.Id,
            City = updateDto.City,
            State = updateDto.State,
            Street1 = updateDto.Street1,
            Street2 = updateDto.Street2
        };

        if (updateDto.CreatedAt != null)
        {
            address.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            address.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return address;
    }
}
