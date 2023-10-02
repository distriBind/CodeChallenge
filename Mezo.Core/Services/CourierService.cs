using Mezo.Core.Mappers;
using Mezo.Core.Shared.Dtos;
using Mezo.Core.Shared.Services;
using Mezo.Data.Entities;
using Mezo.Data.Repositories.Interfaces;

namespace Mezo.Core.Services
{
    public class CourierService : ICourierService
    {
        private readonly IRepository<DeliveryArea> _deliveryAreaRepository;
        private readonly IRepository<Courier> _courierRepository;
        private readonly IPostalCheckService _postalCheckService;
        private readonly IAddressService _addressService;
        private readonly CourierMapper _courierMapper;

        public CourierService(IRepository<DeliveryArea> deliveryAreaRepository, IPostalCheckService postalCheckService, IAddressService addressService, IRepository<Courier> courierRepository)
        {
            _deliveryAreaRepository = deliveryAreaRepository;
            _postalCheckService = postalCheckService;
            _addressService = addressService;
            _courierRepository = courierRepository;
            _courierMapper = new CourierMapper();
        }

        public async Task<CourierDto> GetCourierByAddressId(long addressId)
        {
            var address = await _addressService.GetById(addressId);

            if (address == null)
                throw new InvalidOperationException("No address found");

            if (!await _postalCheckService.EnsureCanDeliverToAddress(addressId))
                throw new InvalidOperationException("No postal service available to cover the area");

            var areas = await _deliveryAreaRepository.GetAllAsync(area => area.Courier);

            //No special courier for particular area, get default one.
            var courier = areas.SingleOrDefault(area => area.AreaName == address.County)?.Courier 
                          ?? 
                          (await _courierRepository.GetAllAsync()).Single(c => c.IsDefaultCourier);

            return _courierMapper.CourierToCourierDto(courier);
        }
    }
}
