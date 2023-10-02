namespace Mezo.Data.Entities;

public class Order : EntityBase
{
    public Customer Customer { get; set; }
    public string Description { get; set; }
}