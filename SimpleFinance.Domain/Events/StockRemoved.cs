using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Events;

public record StockRemoved(StockMarket Stock, Stock StockAction) : IDomainEvent;
