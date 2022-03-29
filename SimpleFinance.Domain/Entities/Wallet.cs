using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Entities;

public class Wallet : AggregateRoot<ObjectId>
{
    public WalletName _name;

    private readonly LinkedList<WalletItem> _items;

    public Wallet(ObjectId id, WalletName walletName)
    {
        Id = id;
        _name = walletName;
        _items = new();
    }

    public Wallet(ObjectId id, WalletName walletName, LinkedList<WalletItem> items)
        :this(id, walletName)
    {
        _items = items;
    }

    public void AddItem(WalletItem item)
    {
        var alreadyExists = _items.Any(i => i.Compare(item));

        if (alreadyExists)
            throw new WalletItemAlreadyExistsException(item.CurrencyName, item.Quantity, _name.Value);

        _items.AddLast(item);
        AddEvent(new WalletItemAdded(this, item));
    }

    public void AddItems(IEnumerable<WalletItem> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void MarkItemAsSold(string currency, double quantity, DateTime dayOfBought, double priceSold)
    {
        var item = GetItem(currency, quantity, dayOfBought);
        var soldItem = item with { DayOfSold = DateTime.Now, PriceSold = priceSold };

        _items.Find(item)!.Value = soldItem;
        AddEvent(new WalletItemSold(this, item));
    }

    public void RemoveItem(string currency, double quantity, DateTime dayOfBought)
    {
        var item = GetItem(currency, quantity, dayOfBought);
        _items.Remove(item);
        AddEvent(new WalletItemRemoved(this, item));
    }

    private WalletItem GetItem(string currency, double quantity, DateTime dayOfBought)
    {
        var item = _items.SingleOrDefault(i => i.CurrencyName == currency 
                                            && i.Quantity == quantity 
                                            && i.DayOfBought.ToShortDateString() == dayOfBought.ToShortDateString());

        if (item is null)
            throw new WalletItemNotFoundException(currency, quantity, dayOfBought);

        return item;
    }
}
