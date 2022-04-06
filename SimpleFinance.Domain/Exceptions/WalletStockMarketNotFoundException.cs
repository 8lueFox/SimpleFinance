using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class WalletStockMarketNotFoundException : AppException
{
    public WalletStockMarketNotFoundException(StockMarketName stockMarketName) :
        base($"Stock market {stockMarketName} cannot be found in list of markets.")
    {
    }
}
