namespace SimpleFinance.Application.Services;

public interface IWalletReadService
{
    Task<bool> ExistsByNameAsync(string name);
}
