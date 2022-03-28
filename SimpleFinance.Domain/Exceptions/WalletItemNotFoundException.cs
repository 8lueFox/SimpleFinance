using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class WalletItemNotFoundException : AppException
{
    public WalletItemNotFoundException(string currency, double quantity, DateTime dayOfBought) :
        base($"Item {currency}|{quantity}|{dayOfBought} cannot be found in list of items.")
    {
    }
}
