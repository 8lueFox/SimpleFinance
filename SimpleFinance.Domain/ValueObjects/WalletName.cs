namespace SimpleFinance.Domain.ValueObjects;

public record WalletName
{
    public string Value { get; }

    public WalletName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EmptyWalletNameException();
        Value = value;
    }

    public static implicit operator string(WalletName name)
        => name.Value;

    public static implicit operator WalletName(string name)
        => new(name);
}
