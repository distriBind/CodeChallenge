using Mezo.Core.Shared.Dtos;
using Mezo.Data.Shared.Services;

namespace Mezo.Core.Shared.Services
{
    public interface IAddressService : IApplicationService
    {
        Task<AddressDto> GetById(long addressId);
    }
}
