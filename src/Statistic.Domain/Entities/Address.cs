namespace Statistic.Domain.Entities;

public record Address(string ZipCode, string Town)
{
    public int Id { get; set; }
    
    public Guid VisitorId { get; set; }
    public Visitor? Visitor { get; set; }
}