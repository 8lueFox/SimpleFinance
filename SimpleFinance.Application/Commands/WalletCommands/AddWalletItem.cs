using MediatR;
using SimpleFinance.Application.Exceptions;
using SimpleFinance.Domain.Enums;
using SimpleFinance.Domain.Repositories;
using SimpleFinance.Domain.ValueObjects;

namespace SimpleFinance.Application.Commands.WalletCommands;

public record AddWalletItem(Guid WalletId, string CurrencyName, float Quantity, float Price, CurrencyType CurrencyType) : IRequest;

internal sealed class AddWalletItemHandler : IRequestHandler<AddWalletItem>
{
    private readonly IWalletRepository _repository;

    public AddWalletItemHandler(IWalletRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(AddWalletItem request, CancellationToken cancellationToken)
    {
        var wallet = await _repository.GetAsync(request.WalletId);

        if (wallet is null)
            throw new WalletNotFoundException(request.WalletId);

        var walletItem = new WalletItem(request.CurrencyName, request.Quantity, request.Price, request.CurrencyType);
        wallet.AddItem(walletItem);

        await _repository.UpdateAsync(wallet);

        return Unit.Value;
    }
}