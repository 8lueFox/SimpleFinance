using SimpleFinance.Application.DTO;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Queries;

internal static class Extensions
{
    public static WalletDto AsDto(this WalletReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Name = readModel.Name,
            Items = readModel.Items.Select(x => new WalletItemDto
            {
                CurrencyName = x.CurrencyName,
                CurrencyType = x.CurrencyType,
                DayOfBought = x.DayOfBought,
                DayOfSold = x.DayOfSold,
                Price = x.Price,
                PriceSold = x.PriceSold,
                Quantity = x.Quantity,
            })
        };
}
