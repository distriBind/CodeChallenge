namespace Mezo.Core.Shared.Dtos
{
    public class CustomerDto : EntityDto
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }
    }

    public class OrderDto : EntityDto
    {
        public string Description { get; set; }
    }
}
