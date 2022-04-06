using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Events;

public record StockActionRemoved(Stock Stock, StockAction StockAction) : IDomainEvent;