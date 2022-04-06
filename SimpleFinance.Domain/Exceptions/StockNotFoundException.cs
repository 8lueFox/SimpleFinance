using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class StockNotFoundException : AppException
{
    public StockNotFoundException(StockName stockName)
        : base($"Stock {stockName} cannot be found.")
    {
    }
}