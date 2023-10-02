namespace Mezo.Data.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(Type type, long id) : base($"Entity type of {type.Name} with Id of {id}, not found")
    {
    }
}