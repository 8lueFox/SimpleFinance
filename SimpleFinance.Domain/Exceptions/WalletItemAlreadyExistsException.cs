using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class WalletItemAlreadyExistsException : AppException
{
    public WalletItemAlreadyExistsException(string currency, double quantity, string name) 
        : base($"Item {currency}|{quantity} already exists in wallet {name}.")
    {
    }
}
