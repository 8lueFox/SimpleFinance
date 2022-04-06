using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class StockActionNotFoundException : AppException
{
    public StockActionNotFoundException(float price, float quantity, DateOnly date, StockActionType actionType) 
        : base($"Stock action like (price: {price}, quantity: {quantity}, date: {date}, action: {actionType.ToString()} cannot be found.")
    {
    }
}
