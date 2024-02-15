using Statistic.Domain.Enums;

namespace Statistic.Domain.Entities;

public class Visitor
{
    public Guid Uid { get; set; }
    public DateTime CreateDate { get; set; }
    public List<VisitorInterests> VisitorInterests { get; set; }
    public Address Address { get; set; }
}