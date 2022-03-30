using Microsoft.EntityFrameworkCore;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.Repositories;
using SimpleFinance.Domain.ValueObjects;
using SimpleFinance.Infrastructure.EF.Contexts;

namespace SimpleFinance.Infrastructure.EF.Repositories;

internal sealed class PostgresWalletRepository : IWalletRepository
{
    private readonly DbSet<Wallet> _wallets;
    private readonly WriteDbContext _writeDbContext;

    public PostgresWalletRepository(WriteDbContext dbContext)
    {
        _wallets = dbContext.Wallets;
        _writeDbContext = dbContext;
    }

    public Task<Wallet> GetAsync(ObjectId id)
        => _wallets.Include("_items").SingleOrDefaultAsync(w => w.Id == id);

    public async Task AddAsync(Wallet wallet)
    {
        await _wallets.AddAsync(wallet);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Wallet wallet)
    {
        _wallets.Remove(wallet);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Wallet wallet)
    {
        _wallets.Update(wallet);
        await _writeDbContext.SaveChangesAsync();
    }
}
