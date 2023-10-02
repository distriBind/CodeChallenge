namespace Mezo.Core.Shared.Dtos
{
    public class AddressDto : EntityDto
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
