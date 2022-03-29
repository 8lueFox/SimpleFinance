namespace SimpleFinance.Application.DTO;

public class WalletDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public IEnumerable<WalletItemDto> Items { get; set; } = new LinkedList<WalletItemDto>();
}
