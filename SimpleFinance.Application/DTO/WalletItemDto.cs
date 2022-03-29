using SimpleFinance.Domain.Enums;

namespace SimpleFinance.Application.DTO;

public class WalletItemDto
{
    public Guid Id { get; set; }

    public string CurrencyName { get; set; } = string.Empty;

    public double Quantity { get; set; }

    public double Price { get; set; }

    public double PriceSold { get; set; }

    public DateTime DayOfBought { get; set; }

    public DateTime DayOfSold { get; set; }

    public CurrencyType CurrencyType { get; }
}
