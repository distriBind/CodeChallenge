using Mezo.Core.Shared.Dtos;
using Mezo.Core.Shared.Services;
using Mezo.Data.Entities;
using Mezo.Data.Repositories.Interfaces;

namespace Mezo.Core.Services
{
    public class PostalCheckService : IPostalCheckService
    {
        private readonly IAddressService _addressService;
        private readonly IRepository<DeliveryArea> _deliveryAreaRepository;

        public PostalCheckService(IAddressService addressService, IRepository<DeliveryArea> deliveryAreaRepository)
        {
            _addressService = addressService;
            _deliveryAreaRepository = deliveryAreaRepository;
        }

        public async Task<bool> EnsureCanDeliverToAddress(long addressId)
        {
            var address = await _addressService.GetById(addressId);

            return await EnsureCanDeliverToAddress(address);
        }

        public async Task<bool> EnsureCanDeliverToAddress(AddressDto addressDto)
        {
            var deliveryAreas = await _deliveryAreaRepository.GetAllAsync();

            var undeliverableAreas = deliveryAreas.Where(area => !area.CanDeliver).Select(area => area.AreaName);

            return !undeliverableAreas.Any(s => s.Equals(addressDto.County) || s.Equals(addressDto.Country));
        }
    }
}
