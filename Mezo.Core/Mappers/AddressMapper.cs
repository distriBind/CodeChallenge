using Mezo.Core.Shared.Dtos;
using Mezo.Data.Entities;
using Riok.Mapperly.Abstractions;

namespace Mezo.Core.Mappers
{
    [Mapper]
    public partial class AddressMapper
    {
        public partial AddressDto AddressToAddressDto(Address address);
    }
}
