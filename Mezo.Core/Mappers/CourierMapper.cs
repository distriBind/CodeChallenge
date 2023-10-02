using Mezo.Core.Shared.Dtos;
using Mezo.Data.Entities;
using Riok.Mapperly.Abstractions;

namespace Mezo.Core.Mappers
{
    [Mapper]
    public partial class CourierMapper
    {
        public partial CourierDto CourierToCourierDto(Courier courier);
    }
}
