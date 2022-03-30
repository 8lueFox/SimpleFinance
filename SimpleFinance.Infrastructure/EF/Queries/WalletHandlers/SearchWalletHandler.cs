using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleFinance.Application.DTO;
using SimpleFinance.Application.Queries.WalletQueries;
using SimpleFinance.Infrastructure.EF.Contexts;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Queries.WalletHandlers;

internal sealed class SearchWalletHandler : IRequestHandler<SearchWallet, IEnumerable<WalletDto>>
{
    private readonly DbSet<WalletReadModel> _wallets;

    public SearchWalletHandler(ReadDbContext context)
        => _wallets = context.Wallets;

    public async Task<IEnumerable<WalletDto>> Handle(SearchWallet request, CancellationToken cancellationToken)
    {
        var dbQuery = _wallets
            .Include(x => x.Items)
            .AsQueryable();

        if(request.SearchPhrase is not null)
        {
            dbQuery = dbQuery.Where(pl =>
                Microsoft.EntityFrameworkCore.EF.Functions.ILike(pl.Name, $"%{request.SearchPhrase}%"));
        }

        return await dbQuery
            .Select(w => w.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}
