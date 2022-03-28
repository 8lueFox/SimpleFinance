using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class ZeroPriceSoldException : AppException
{
    public ZeroPriceSoldException() : base("Selling price cannot be 0.")
    {
    }
}
