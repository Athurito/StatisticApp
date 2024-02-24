namespace Statistic.Infrastructure.Service;

public interface IDatabaseService
{
    /// <summary>
    /// Ensures that the database is created and initialized with the required tables
    /// </summary>
    public void EnsureDataBase();

    /// <summary>
    /// Seeds the database with initial data if it has not been seeded already.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SeedDataBaseAsync();
}