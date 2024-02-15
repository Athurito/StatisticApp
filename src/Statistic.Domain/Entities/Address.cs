namespace Statistic.Domain.Entities;

public class Address
{
    public int Id { get; set; }
    public required string ZipCode { get; set; }
    public required string Town { get; set; }
    public required string FederalState { get; set; }
    public required string District { get; set; }
    public Visitor? Visitor { get; set; }
}