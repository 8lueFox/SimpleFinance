using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Application.Exceptions;

public class WalletNotFoundException : AppException
{
    public WalletNotFoundException(Guid walletId) 
        : base($"Wallet with ID {walletId} cannot be found.")
    {
    }
}
