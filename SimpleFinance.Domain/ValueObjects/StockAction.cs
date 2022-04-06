namespace SimpleFinance.Domain.ValueObjects;

public record StockAction
{
    public StockAction(float Price, float Quantity, StockActionType ActionType, DateOnly Date)
    {
        this.Price = Price;
        this.Quantity = Quantity;
        this.ActionType = ActionType;
        this.Date = Date;
    }

    public float Price { get; }

    public float Quantity { get; }

    public DateOnly Date { get; }

    public StockActionType ActionType { get; }
}
