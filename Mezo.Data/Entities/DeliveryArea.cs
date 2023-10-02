namespace Mezo.Data.Entities
{
    public class DeliveryArea : EntityBase
    {
        public string AreaName { get; set; }
        public bool CanDeliver { get; set; }
        public long? CourierId { get; set; }
        public Courier Courier { get; set; }
    }
}
