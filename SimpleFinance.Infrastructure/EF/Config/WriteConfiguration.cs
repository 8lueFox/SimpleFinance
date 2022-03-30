using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.ValueObjects;
using SimpleFinance.Infrastructure.EF.Consts;

namespace SimpleFinance.Infrastructure.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<Wallet>, IEntityTypeConfiguration<WalletItem>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.HasKey(x => x.Id);

        var walletNameConverter = new ValueConverter<WalletName, string>(w => w.Value, w => new WalletName(w));

        builder
            .Property(x => x.Id)
            .HasConversion(id => id.Value, id => new ObjectId(id, "Wallet"));

        builder
            .Property(typeof(WalletName), "_name")
            .HasConversion(walletNameConverter)
            .HasColumnName("Name");

        builder
            .HasMany(typeof(WalletItem), "_items");

        builder.ToTable(DatabaseNames.WalletTableName);
    }

    public void Configure(EntityTypeBuilder<WalletItem> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(x => x.CurrencyName);
        builder.Property(x => x.Quantity);
        builder.Property(x => x.Price);
        builder.Property(x => x.PriceSold);
        builder.Property(x => x.DayOfBought);
        builder.Property(x => x.DayOfSold);
        builder.Property(x => x.CurrencyType);

        builder.ToTable(DatabaseNames.WalletItemsTableName);
    }
}
