using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Entities;

public class StockMarket : AggregateRoot<ObjectId>
{
    public ObjectId Id { get; set; }

    public readonly StockMarketName _name;
    private readonly LinkedList<Stock> _stocks;

    public StockMarket()
    {
    }

    public StockMarket(ObjectId id, StockMarketName name)
    {
        Id = id;
        _name = name;
        _stocks = new();
    }

    public StockMarket(ObjectId id, StockMarketName name, LinkedList<Stock> actions)
        : this(id, name)
    {
        _stocks = actions;
    }

    public void AddItem(Stock item)
    {
        if (_stocks.Any(s => s._name == item._name))
            throw new StockAlreadyExistsException(item._name);

        _stocks.AddLast(item);
        AddEvent(new StockAdded(this, item));
    }

    public void AddItems(IEnumerable<Stock> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void RemoveItem(StockName stockName)
    {
        var item = GetItem(stockName);
        _stocks.Remove(item);
        AddEvent(new StockRemoved(this, item));
    }

    private Stock GetItem(StockName stockName)
    {
        var item = _stocks.SingleOrDefault(i => i._name == stockName);

        if (item is null)
            throw new StockNotFoundException(stockName);

        return item;
    }
}
