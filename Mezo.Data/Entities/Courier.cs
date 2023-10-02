namespace Mezo.Data.Entities
{
    public class Courier : EntityBase
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public bool IsDefaultCourier { get; set; }
    }
}
