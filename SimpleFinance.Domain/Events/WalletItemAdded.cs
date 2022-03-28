using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Events;

public record WalletItemAdded(Wallet PackingList, WalletItem item) : IDomainEvent;
