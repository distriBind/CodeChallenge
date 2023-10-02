using Mezo.Core.Mappers;
using Mezo.Core.Shared.Dtos;
using Mezo.Core.Shared.Services;
using Mezo.Data.Entities;
using Mezo.Data.Repositories.Interfaces;

namespace Mezo.Core.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly AddressMapper _addressMapper;

        public AddressService(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
            _addressMapper = new AddressMapper();
        }

        public async Task<AddressDto> GetById(long addressId)
        {
            return _addressMapper.AddressToAddressDto(await _addressRepository.GetByIdAsync(addressId));
        }
    }
}
