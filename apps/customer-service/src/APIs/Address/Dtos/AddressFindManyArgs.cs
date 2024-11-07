using CustomerService.APIs.Common;
using CustomerService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class AddressFindManyArgs : FindManyInput<Address, AddressWhereInput> { }
