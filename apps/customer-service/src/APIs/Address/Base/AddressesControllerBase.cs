using CustomerService.APIs;
using CustomerService.APIs.Common;
using CustomerService.APIs.Dtos;
using CustomerService.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AddressesControllerBase : ControllerBase
{
    protected readonly IAddressesService _service;

    public AddressesControllerBase(IAddressesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Address
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Address>> CreateAddress(AddressCreateInput input)
    {
        var address = await _service.CreateAddress(input);

        return CreatedAtAction(nameof(Address), new { id = address.Id }, address);
    }

    /// <summary>
    /// Delete one Address
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteAddress([FromRoute()] AddressWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteAddress(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Addresses
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Address>>> Addresses(
        [FromQuery()] AddressFindManyArgs filter
    )
    {
        return Ok(await _service.Addresses(filter));
    }

    /// <summary>
    /// Meta data about Address records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AddressesMeta(
        [FromQuery()] AddressFindManyArgs filter
    )
    {
        return Ok(await _service.AddressesMeta(filter));
    }

    /// <summary>
    /// Get one Address
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Address>> Address([FromRoute()] AddressWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Address(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Address
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateAddress(
        [FromRoute()] AddressWhereUniqueInput uniqueId,
        [FromQuery()] AddressUpdateInput addressUpdateDto
    )
    {
        try
        {
            await _service.UpdateAddress(uniqueId, addressUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
