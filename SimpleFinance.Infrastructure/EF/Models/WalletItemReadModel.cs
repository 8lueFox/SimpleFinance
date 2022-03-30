using SimpleFinance.Domain.Enums;

namespace SimpleFinance.Infrastructure.EF.Models;

internal class WalletItemReadModel
{
    public Guid Id { get; set; }

    public string CurrencyName { get; set; }

    public float Quantity { get; set; }

    public float Price { get; set; }

    public float? PriceSold { get; set; }

    public DateTime DayOfBought { get; set; }

    public DateTime? DayOfSold { get; set; }

    public CurrencyType CurrencyType { get; set; }

    public WalletReadModel Wallet { get; set; }
}
