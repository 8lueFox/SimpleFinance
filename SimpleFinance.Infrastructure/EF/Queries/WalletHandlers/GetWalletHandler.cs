using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleFinance.Application.DTO;
using SimpleFinance.Application.Queries.WalletQueries;
using SimpleFinance.Infrastructure.EF.Contexts;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Queries.WalletHandlers;

internal sealed class GetWalletHandler : IRequestHandler<GetWallet, WalletDto>
{
    private readonly DbSet<WalletReadModel> _wallets;

    public GetWalletHandler(ReadDbContext context)
        => _wallets = context.Wallets;

    Task<WalletDto> IRequestHandler<GetWallet, WalletDto>.Handle(GetWallet request, CancellationToken cancellationToken)
    {
        return _wallets
            .Include(w => w.Items)
            .Where(w => w.Id == request.id)
            .Select(w => w.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
}
