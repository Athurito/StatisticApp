using Statistic.Domain.Enums;

namespace Statistic.Domain.Entities;

public class VisitorInterests
{
    public Guid VisitorId { get; set; }
    public Visitor Visitor { get; set; }
    public Interests Interest { get; set; }
}