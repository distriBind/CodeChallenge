using Mezo.Core.Shared.Dtos;
using Mezo.Data.Shared.Services;

namespace Mezo.Core.Shared.Services;

public interface IPostalCheckService : IApplicationService
{
    Task<bool> EnsureCanDeliverToAddress(long addressId);
    Task<bool> EnsureCanDeliverToAddress(AddressDto addressDto);
}