using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.ValueObjects;

public class Stock : AggregateRoot<ObjectId>
{
    public ObjectId Id { get; set; }

    public StockType StockType { get; set; }

    public float StockSum { get; set; }

    public readonly StockName _name;
    private readonly LinkedList<StockAction> _actions;

    public Stock()
    {
    }

    public Stock(ObjectId id, StockName name, StockType stockType)
    {
        Id = id;
        _name = name;
        StockType = stockType;
        StockSum = 0;
        _actions = new();
    }

    public Stock(ObjectId id, StockName name, int stockType)
        : this(id, name, (StockType) stockType)
    {
    }

    public Stock(ObjectId id, StockName name, StockType stockType, LinkedList<StockAction> actions)
        : this(id, name, stockType)
    {
        _actions = actions;
    }

    public void AddItem(StockAction item)
    {
        _actions.AddLast(item);
        StockSum = item.ActionType == StockActionType.Buy ? StockSum + item.Quantity : StockSum - item.Quantity;
        AddEvent(new StockActionAdded(this, item));
    }

    public void AddItems(IEnumerable<StockAction> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void RemoveItem(float price, float quantity, DateOnly date, StockActionType actionType)
    {
        var item = GetItem(price, quantity, date, actionType);
        _actions.Remove(item);
        AddEvent(new StockActionRemoved(this, item));
    }

    private StockAction GetItem(float price, float quantity, DateOnly date, StockActionType actionType)
    {
        var item = _actions.SingleOrDefault(i => i.Price == price
                                              && i.Quantity == quantity
                                              && i.Date == date
                                              && i.ActionType == actionType);

        if (item is null)
            throw new StockActionNotFoundException(price, quantity, date, actionType);

        return item;
    }
}
