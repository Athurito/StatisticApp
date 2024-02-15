namespace Statistic.Domain.Entities;

public class Address
{
    public int Id { get; set; }
    public string ZipCode { get; set; }
    public string Town { get; set; }
    public string FederalState { get; set; }
    public string District { get; set; }
    public Visitor? Visitor { get; set; }
}