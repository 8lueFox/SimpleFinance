using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class EmptyStockMarketNameException : AppException
{
    public EmptyStockMarketNameException() : base("Stock market name cannot be empty.")
    {
    }
}
