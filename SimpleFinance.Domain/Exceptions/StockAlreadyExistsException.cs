using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class StockAlreadyExistsException : AppException
{
    public StockAlreadyExistsException(StockName stockName) 
        : base($"Stock {stockName} already exists.")
    {
    }
}
