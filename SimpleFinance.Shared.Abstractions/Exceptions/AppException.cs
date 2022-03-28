namespace SimpleFinance.Shared.Abstractions.Exceptions;

public abstract class AppException : Exception
{
    protected AppException(string msg)
        : base(msg) { }
}
