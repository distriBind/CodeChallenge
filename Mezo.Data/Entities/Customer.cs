namespace Mezo.Data.Entities
{
    public class Customer : EntityBase
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
