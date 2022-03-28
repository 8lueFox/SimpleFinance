using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class EmptyWalletNameException : AppException
{
    public EmptyWalletNameException() : base("Wallet name cannot be empty.")
    {
    }
}
