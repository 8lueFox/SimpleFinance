using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class EmptyStockNameException : AppException
{
    public EmptyStockNameException() : base("Stock name cannot be empty.")
    {
    }
}
