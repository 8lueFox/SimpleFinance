using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Events;

public record WalletStockMarketAdded(Wallet Wallet, StockMarket item) : IDomainEvent;
