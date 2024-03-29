﻿using SimpleFinance.Domain.Enums;

namespace SimpleFinance.Application.DTO;

public class WalletItemDto
{
    public Guid Id { get; set; }

    public string CurrencyName { get; set; } = string.Empty;

    public float Quantity { get; set; }

    public float Price { get; set; }

    public float? PriceSold { get; set; }

    public DateTime DayOfBought { get; set; }

    public DateTime? DayOfSold { get; set; }

    public CurrencyType CurrencyType { get; set; }
}
