using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Events;

public record WalletItemSold(Wallet PackingList, WalletItem item) : IDomainEvent;
