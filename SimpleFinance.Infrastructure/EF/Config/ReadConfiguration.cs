using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleFinance.Infrastructure.EF.Consts;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<WalletReadModel>, IEntityTypeConfiguration<WalletItemReadModel>
{
    public void Configure(EntityTypeBuilder<WalletReadModel> builder)
    {
        builder.ToTable(DatabaseNames.WalletTableName);
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Items)
            .WithOne(x => x.Wallet);
            
    }

    public void Configure(EntityTypeBuilder<WalletItemReadModel> builder)
    {
        builder.Property(x => x.PriceSold).IsRequired(false);
        builder.Property(x => x.DayOfSold).IsRequired(false);
        builder.ToTable(DatabaseNames.WalletItemsTableName);
    }
}
