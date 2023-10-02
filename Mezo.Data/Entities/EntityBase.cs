namespace Mezo.Data.Entities;
public class EntityBase<T>
{
    public T Id { get; set; }
}

/// <summary>
/// Default entity class with long for Id property.
/// </summary>
public class EntityBase : EntityBase<long>
{

}