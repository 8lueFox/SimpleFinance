namespace SimpleFinance.Domain.ValueObjects;

public record WalletItem
{
    public WalletItem(string currencyName, double quantity, double price, CurrencyType currencyType)
    {
        CurrencyName = currencyName;
        Quantity = quantity;
        Price = price;
        DayOfBought = DateTime.Now;
        CurrencyType = currencyType;
    }

    public string CurrencyName { get; }
    public double Quantity { get; }
    public double Price { get; }
    public double? PriceSold { get; set; }
    public CurrencyType CurrencyType { get; }
    public DateTime DayOfBought { get; }
    public DateTime? DayOfSold { get; set; }

    public void MarkAsSold(double priceSold)
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
