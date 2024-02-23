namespace Statistic.Infrastructure.Exceptions;

public class DbConnectionException : Exception
{
    public DbConnectionException(string message) : base(message)
    {
        
    }
}