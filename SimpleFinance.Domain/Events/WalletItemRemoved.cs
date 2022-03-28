using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Events;

public record WalletItemRemoved(Wallet PackingList, WalletItem item) : IDomainEvent;
