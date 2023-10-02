namespace Mezo.Core.Shared.Dtos;

public class EntityDto : EntityDto<long>
{
}

public class EntityDto<T>
{
    public T Id { get; set; }
}