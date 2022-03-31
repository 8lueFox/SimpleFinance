using MediatR;
using NSubstitute;
using Shouldly;
using SimpleFinance.Application.Commands.WalletCommands;
using SimpleFinance.Application.Exceptions;
using SimpleFinance.Application.Services;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SimpleFinance.UnitTests.Application.CommandsTests.WalletTests;

public class CreateWalletTest
{
    Task Act(CreateWallet command)
        => requestHandler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task Handle_Throws_WalletAlreadyExistsException_When_List_With_Same_Name_Already_Exists()
    {
        var command = new CreateWallet(System.Guid.NewGuid(), "TestWallet");

        readService.ExistsByNameAsync(command.Name).Returns(true);

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<WalletAlreadyExistsException>(); 
    }

    [Fact]
    public async Task Handle_Calls_Repository_On_Success()
    {
        var command = new CreateWallet(System.Guid.NewGuid(), "TestWallet");

        readService.ExistsByNameAsync(command.Name).Returns(false);

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldBeNull();
        await repository.Received(1).AddAsync(Arg.Any<Wallet>());
    }

    #region ARRANGE
    private readonly IRequestHandler<CreateWallet> requestHandler;
    private readonly IWalletRepository repository;
    private readonly IWalletReadService readService;

    public CreateWalletTest()
    {
        repository = Substitute.For<IWalletRepository>();
        readService = Substitute.For<IWalletReadService>();

        requestHandler = new CreateWalletHandler(repository, readService);
    }
    #endregion
}
