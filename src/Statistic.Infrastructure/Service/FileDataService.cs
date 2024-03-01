namespace Statistic.Infrastructure.Service;

public class FileDataService : IDatabaseService
{
    public void EnsureDataBase()
    {
        
    }

    public Task SeedDataBaseAsync()
    {
        return Task.FromResult(0);
    }
}