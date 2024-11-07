using CustomerService.APIs.Common;
using CustomerService.APIs.Dtos;

namespace CustomerService.APIs;

public interface IAddressesService
{
    /// <summary>
    /// Create one Address
    /// </summary>
    public Task<Address> CreateAddress(AddressCreateInput address);

    /// <summary>
    /// Delete one Address
    /// </summary>
    public Task DeleteAddress(AddressWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Addresses
    /// </summary>
    public Task<List<Address>> Addresses(AddressFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Address records
    /// </summary>
    public Task<MetadataDto> AddressesMeta(AddressFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Address
    /// </summary>
    public Task<Address> Address(AddressWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Address
    /// </summary>
    public Task UpdateAddress(AddressWhereUniqueInput uniqueId, AddressUpdateInput updateDto);
}
