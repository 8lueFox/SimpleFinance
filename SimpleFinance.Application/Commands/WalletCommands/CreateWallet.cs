using MediatR;
using SimpleFinance.Application.Exceptions;
using SimpleFinance.Application.Services;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.Repositories;
using SimpleFinance.Domain.ValueObjects;

namespace SimpleFinance.Application.Commands.WalletCommands;

public record CreateWallet(Guid Id, string Name) : IRequest;

public sealed class CreateWalletHandler : IRequestHandler<CreateWallet>
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

        ObjectId oid = new ObjectId(id, "Wallet");
        Wallet wallet = new Wallet(oid, name);

        await _repository.AddAsync(wallet);

        return Unit.Value;
    }
}
