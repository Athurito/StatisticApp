using System.Text.Json;
using Statistic.Domain.Entities;
using Statistic.Domain.Repositories;

namespace Statistic.Infrastructure.FileRepositories;

public class FileVisitorRepository : IVisitorRepository
{
    private readonly IAddressRepository _addressRepository;
    private const string FilePath = "visitors.json";

    public FileVisitorRepository(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }
    public async Task CreateVisitor(Visitor visitor)
    {
        List<Visitor> visitors =
        [
            ..await GetAll(),
            visitor
        ];
        
        await SaveVisitorsAsync(visitors);
    }

    public async Task<IEnumerable<Visitor>> GetAll()
    {
        if (!File.Exists(FilePath))
        {
            return Enumerable.Empty<Visitor>();
        }

        await using var stream = File.OpenRead(FilePath);
        
        var visitors = await JsonSerializer.DeserializeAsync<List<Visitor>>(stream) ?? [];
        List<Address> addresses = [..await _addressRepository.GetAll()];
        foreach (var visitor in visitors)
        {
            visitor.Address = addresses.FirstOrDefault(a => a.Id == visitor.AddressId);
        }
        
        return visitors;
    }
    
    private static async Task SaveVisitorsAsync(List<Visitor> visitors)
    {
        await using var stream = File.Create(FilePath);
        await JsonSerializer.SerializeAsync(stream, visitors);
    }
}