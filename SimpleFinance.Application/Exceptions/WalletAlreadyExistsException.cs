using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Application.Exceptions;

public class WalletAlreadyExistsException : AppException
{
    public WalletAlreadyExistsException(string name) 
        : base($"Wallet with name {name} already exists.")
    {
    }
}
