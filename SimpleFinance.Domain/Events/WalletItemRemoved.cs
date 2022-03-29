using SimpleFinance.Shared.Abstractions.Domain;

namespace SimpleFinance.Domain.Events;

public record WalletItemRemoved(Wallet Wallet, WalletItem item) : IDomainEvent;
