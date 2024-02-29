using Statistic.Domain.Enums;

namespace Statistic.Domain.Entities;

public class VisitorAttentions
{
    public Guid VisitorId { get; set; }
    public Visitor? Visitor { get; set; }
    public Attentions Attention { get; set; }
}