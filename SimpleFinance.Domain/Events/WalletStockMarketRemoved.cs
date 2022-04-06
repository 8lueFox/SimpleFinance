using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Events;

public record WalletStockMarketRemoved(Wallet Wallet, StockMarket item) : IDomainEvent;
