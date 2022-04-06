namespace SimpleFinance.Domain.ValueObjects;

public record StockMarketName
{
    public string Value { get; }

    public StockMarketName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EmptyStockMarketNameException();
        Value = value;
    }

    public static implicit operator string(StockMarketName name)
        => name.Value;

    public static implicit operator StockMarketName(string name)
        => new(name);
}
