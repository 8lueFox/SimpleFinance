using Shouldly;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.Enums;
using SimpleFinance.Domain.Events;
using SimpleFinance.Domain.Exceptions;
using SimpleFinance.Domain.ValueObjects;
using System;
using System.Linq;
using Xunit;

namespace SimpleFinance.UnitTests.Domain;

public class WalletTests
{
    [Fact]
    public void AddItem_Throws_WalletItemAlreadyExistsException_When_There_Is_Already_The_Same_Value()
    {
        //ARRANGE
        var wallet = GetWallet();
        WalletItem walletItem = new("BTC", 20, 10000, CurrencyType.Crypto);
        wallet.AddItem(walletItem);

        //ACT
        var exception = Record.Exception(() => wallet.AddItem(walletItem));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<WalletItemAlreadyExistsException>();
    }

    [Fact]
    public void AddItem_Adds_WalletItemAdded_Domain_Event_Success()
    {
        var wallet = GetWallet();
        WalletItem walletItem = new("BTC", 20, 10000, CurrencyType.Crypto);

        var exception = Record.Exception(() => wallet.AddItem(walletItem));

        exception.ShouldBeNull();
        wallet.Events.Count().ShouldBe(1);

        var @event = wallet.Events.FirstOrDefault() as WalletItemAdded;

        @event.ShouldNotBeNull();

        @event.item.CurrencyName.ShouldBe("BTC");
        @event.item.Quantity.ShouldBe(20);
        @event.item.Price.ShouldBe(10000);
        @event.item.CurrencyType.ShouldBe(CurrencyType.Crypto);
    }

    [Fact]
    public void MarkItemAsSold_Throws_WalletItemNotFoundException_When_Item_In_List_Doesnt_Exists()
    {
        var wallet = GetWallet();

        var exception = Record.Exception(() => wallet.MarkItemAsSold("BTC", 20, DateTime.Now, 30));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<WalletItemNotFoundException>();
    }

    [Fact]
    public void MarkItemAsSold_Mark_Item_In_Wallet_As_Sold()
    {
        var wallet = GetWallet();
        WalletItem walletItem = new("BTC", 20, 10000, CurrencyType.Crypto);
        wallet.AddItem(walletItem);
        wallet.ClearEvents();

        var exception = Record.Exception(() => wallet.MarkItemAsSold(walletItem.CurrencyName, walletItem.Quantity, walletItem.DayOfBought, 11000));

        exception.ShouldBeNull();
        wallet.Events.Count().ShouldBe(1);

        var @event = wallet.Events.FirstOrDefault() as WalletItemSold;

        @event.ShouldNotBeNull();

        @event.item.PriceSold.ShouldBeNull();
        @event.item.DayOfSold.ShouldBeNull();
    }

    [Fact]
    public void RemoveItem_Adds_WalletItemRemoved_Domain_Event_Success()
    {
        var wallet = GetWallet();
        WalletItem walletItem = new("BTC", 20, 10000, CurrencyType.Crypto);
        wallet.AddItem(walletItem);
        wallet.ClearEvents();

        var exception = Record.Exception(() => wallet.RemoveItem(walletItem.CurrencyName, walletItem.Quantity, walletItem.DayOfBought));

        exception.ShouldBeNull();
        wallet.Events.Count().ShouldBe(1);

        var @event = wallet.Events.FirstOrDefault() as WalletItemRemoved;

        @event.ShouldNotBeNull();

        @event.item.ShouldBe(walletItem);
    }

    #region ARRANGE
    private Wallet GetWallet()
    {
        var wallet = new Wallet(new ObjectId(Guid.NewGuid(), "Wallet"), "Portfel bezpieczny");
        wallet.ClearEvents();
        return wallet;
    }
    #endregion
}
