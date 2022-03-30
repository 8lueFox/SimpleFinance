namespace SimpleFinance.Infrastructure.EF.Models;

internal class WalletReadModel
{
    public Guid Id { get; set; }

    public int Version { get; set; }

    public string Name { get; set; }

    public ICollection<WalletItemReadModel> Items { get; set; }
}
