using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Domain.Exceptions;

public class EmptyObjectIdException : AppException
{
    public EmptyObjectIdException(string? objWhichNeedId)
        : base(string.IsNullOrWhiteSpace(objWhichNeedId)
            ? "Object ID cannot be empty."
            : $"{objWhichNeedId} ID cannot be empty.")
    {
    }
}
