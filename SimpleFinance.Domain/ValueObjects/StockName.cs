namespace SimpleFinance.Domain.ValueObjects;

public record StockName
{
    public string Value { get; }

    public StockName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EmptyStockNameException();
        Value = value;
    }

    public static implicit operator string(StockName name)
        => name.Value;

    public static implicit operator StockName(string name)
        => new(name);
}