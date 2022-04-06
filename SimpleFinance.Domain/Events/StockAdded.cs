using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Events;

public record StockAdded(StockMarket Stock, Stock StockAction) : IDomainEvent;