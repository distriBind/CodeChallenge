using Mezo.Core.Shared.Dtos;
using Mezo.Data.Entities;
using Riok.Mapperly.Abstractions;

namespace Mezo.Core.Mappers
{
    [Mapper]
    public partial class CustomerMapper
    {
        [MapperIgnoreTarget(nameof(CustomerDto.Orders))]
        public partial CustomerDto CustomerToCustomerDto(Customer customer);
    }
}
