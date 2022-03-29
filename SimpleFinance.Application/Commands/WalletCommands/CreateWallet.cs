using MediatR;
using SimpleFinance.Application.Exceptions;
using SimpleFinance.Application.Services;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.Repositories;

namespace SimpleFinance.Application.Commands.WalletCommands;

public record CreateWallet(Guid Id, string Name) : IRequest;

internal sealed class CreateWalletHandler : IRequestHandler<CreateWallet>
{
    private readonly IWalletRepository _repository;
    private readonly IWalletReadService _readService;

    public CreateWalletHandler(IWalletRepository repository, IWalletReadService readService)
    {
        _repository = repository;
        _readService = readService;
    }

    public async Task<Unit> Handle(CreateWallet request, CancellationToken cancellationToken)
    {
        var (id, name) = request;

        if (await _readService.ExistsByNameAsync(name))
            throw new WalletAlreadyExistsException(name);

        Wallet wallet = new(id, name);

        await _repository.AddAsync(wallet);

        return Unit.Value;
    }
}
