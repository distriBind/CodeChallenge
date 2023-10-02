using Mezo.Core.Shared.Dtos;
using Mezo.Data.Shared.Services;

namespace Mezo.Core.Shared.Services
{
    public interface ICourierService : IApplicationService
    {
        Task<CourierDto> GetCourierByAddressId(long addressId);
    }
}
