using System.Reflection;
using System.Text.Json;
using Statistic.Domain.Entities;
using Statistic.Domain.Repositories;

namespace Statistic.Infrastructure.FileRepositories;

public class FileAddressRepository : IAddressRepository
{
    public async Task<IEnumerable<Address>> GetAll()
    {
        var assembly = Assembly.GetExecutingAssembly();
        const string resourceName = "Statistic.Infrastructure.addresses.json";

        await using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
        {
            throw new Exception($"Resource {resourceName} not found.");
        }
        using var reader = new StreamReader(stream);
        var json = await reader.ReadToEndAsync();
        var addresses = JsonSerializer.Deserialize<List<Address>>(json);
        
        return addresses ?? Enumerable.Empty<Address>();
    }
}