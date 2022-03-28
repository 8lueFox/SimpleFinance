namespace SimpleFinance.Domain.ValueObjects;

public record ObjectId
{
    public Guid Value { get; }

    public ObjectId(Guid value, string? objWhichNeedId)
    {
        if (value == Guid.Empty)
            throw new EmptyObjectIdException(objWhichNeedId);
        Value = value;
    }

    public static implicit operator Guid(ObjectId id)
        => id.Value;

    public static implicit operator ObjectId(Guid id)
        => new(id);
}
