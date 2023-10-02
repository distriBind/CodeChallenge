namespace Mezo.Core.Shared.Dtos
{
    public class CourierDto : EntityDto
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public bool IsDefaultCourier { get; set; }
    }
}
