using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class EmptyCurrencyName : AppException
{
    public EmptyCurrencyName() : base("Currency name cannot be empty.")
    {
    }
}
