namespace Statistic.Domain.Entities;

public class Address
{
    public int Id { get; init; }
    public required string ZipCode { get; init; }
    public required string Town { get; init; }
    public required string FederalState { get; init; }
    public required string District { get; init; }
    public ICollection<Visitor>? Visitors { get; set; } = [];
}
