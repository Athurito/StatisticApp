using Statistic.Infrastructure.Data;
using Statistic.Infrastructure.Exceptions;

namespace Statistic.Infrastructure.Repositories;

public class BaseRepository
{
    protected void EnsureConnection(StatisticDbContext context)
    {
        if (!context.Database.CanConnect())
        {
            throw new DbConnectionException("Fehler beim Verbinden zur Datenbank");
        }
    }
}