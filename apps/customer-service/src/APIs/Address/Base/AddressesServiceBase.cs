using CustomerService.APIs;
using CustomerService.APIs.Common;
using CustomerService.APIs.Dtos;
using CustomerService.APIs.Errors;
using CustomerService.APIs.Extensions;
using CustomerService.Infrastructure;
using CustomerService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.APIs;

public abstract class AddressesServiceBase : IAddressesService
{
    protected readonly CustomerServiceDbContext _context;

    public AddressesServiceBase(CustomerServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Address
    /// </summary>
    public async Task<Address> CreateAddress(AddressCreateInput createDto)
    {
        var address = new AddressDbModel
        {
            City = createDto.City,
            CreatedAt = createDto.CreatedAt,
            State = createDto.State,
            Street1 = createDto.Street1,
            Street2 = createDto.Street2,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            address.Id = createDto.Id;
        }

        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AddressDbModel>(address.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Address
    /// </summary>
    public async Task DeleteAddress(AddressWhereUniqueInput uniqueId)
    {
        var address = await _context.Addresses.FindAsync(uniqueId.Id);
        if (address == null)
        {
            throw new NotFoundException();
        }

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Addresses
    /// </summary>
    public async Task<List<Address>> Addresses(AddressFindManyArgs findManyArgs)
    {
        var addresses = await _context
            .Addresses.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return addresses.ConvertAll(address => address.ToDto());
    }

    /// <summary>
    /// Meta data about Address records
    /// </summary>
    public async Task<MetadataDto> AddressesMeta(AddressFindManyArgs findManyArgs)
    {
        var count = await _context.Addresses.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Address
    /// </summary>
    public async Task<Address> Address(AddressWhereUniqueInput uniqueId)
    {
        var addresses = await this.Addresses(
            new AddressFindManyArgs { Where = new AddressWhereInput { Id = uniqueId.Id } }
        );
        var address = addresses.FirstOrDefault();
        if (address == null)
        {
            throw new NotFoundException();
        }

        return address;
    }

    /// <summary>
    /// Update one Address
    /// </summary>
    public async Task UpdateAddress(AddressWhereUniqueInput uniqueId, AddressUpdateInput updateDto)
    {
        var address = updateDto.ToModel(uniqueId);

        _context.Entry(address).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Addresses.Any(e => e.Id == address.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
