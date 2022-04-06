using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Entities;

public class Wallet : AggregateRoot<ObjectId>
{
    public WalletName _name;

    private readonly LinkedList<StockMarket> _markets;

    public Wallet()
    {

    }

    public Wallet(ObjectId id, WalletName walletName)
    {
        Id = id;
        _name = walletName;
        _markets = new();
    }

    public Wallet(ObjectId id, WalletName walletName, LinkedList<StockMarket> items)
        :this(id, walletName)
    {
        _markets = items;
    }

    public void AddItem(StockMarket item)
    {
        var alreadyExists = _markets.Any(i => i._name == item._name);

        if (alreadyExists)
            throw new WalletStockMarketAlreadyExistsException(item._name, _name);

        _markets.AddLast(item);
        AddEvent(new WalletStockMarketAdded(this, item));
    }

    public void AddItems(IEnumerable<StockMarket> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void RemoveItem(StockMarket stockMarket)
    {
        var item = GetItem(stockMarket);
        _markets.Remove(item);
        AddEvent(new WalletStockMarketRemoved(this, item));
    }

    private StockMarket GetItem(StockMarket stockMarket)
    {
        var item = _markets.SingleOrDefault(i => i._name == stockMarket._name);

        if (item is null)
            throw new WalletStockMarketNotFoundException(stockMarket._name);

        return item;
    }
}
