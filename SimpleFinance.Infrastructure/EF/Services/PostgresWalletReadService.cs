using Microsoft.EntityFrameworkCore;
using SimpleFinance.Application.Services;
using SimpleFinance.Infrastructure.EF.Contexts;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Services;

internal sealed class PostgresWalletReadService : IWalletReadService
{
    private readonly DbSet<WalletReadModel> _wallets;

    public PostgresWalletReadService(ReadDbContext context)
        => _wallets = context.Wallets;

    public Task<bool> ExistsByNameAsync(string name)
        => _wallets.AnyAsync(x => x.Name == name);
}
