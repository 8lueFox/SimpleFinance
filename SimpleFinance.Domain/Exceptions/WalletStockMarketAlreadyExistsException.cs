using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class WalletStockMarketAlreadyExistsException : AppException
{
    public WalletStockMarketAlreadyExistsException(StockMarketName stockMarketName, WalletName name) 
        : base($"Item {stockMarketName} already exists in wallet {name}.")
    {
    }
}
