namespace SimpleFinance.Domain.ValueObjects;

public record WalletItem
{
    public WalletItem(string currencyName, float quantity, float price, CurrencyType currencyType)
    {
        CurrencyName = currencyName;
        Quantity = quantity;
        Price = price;
        DayOfBought = DateTime.UtcNow;
        CurrencyType = currencyType;
    }

    public string CurrencyName { get; }
    public float Quantity { get; }
    public float Price { get; }
    public float? PriceSold { get; set; }
    public CurrencyType CurrencyType { get; }
    public DateTime DayOfBought { get; }
    public DateTime? DayOfSold { get; set; }

    public void MarkAsSold(float priceSold)
    {
        if (priceSold == 0d)
            throw new ZeroPriceSoldException();
        DayOfSold = DateTime.Now;
        PriceSold = priceSold;
    }

    public bool Compare(object obj)
    {
        if (obj == null || obj is not WalletItem)
            return false;

        var item = (WalletItem)obj;

        if(CurrencyName == item.CurrencyName 
           && Quantity == item.Quantity
           && Price == item.Price
           && DayOfBought == item.DayOfBought)
            return true;

        return false;
    }
}
