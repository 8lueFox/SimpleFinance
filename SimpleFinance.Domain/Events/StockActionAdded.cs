using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Events;

public record StockActionAdded(Stock Stock, StockAction StockAction) : IDomainEvent;
