using Statistic.Application.DTOs;
using Statistic.Application.Pdf.HelperModels;

namespace Statistic.Application.Pdf;

public class VisitorStatistic
{
    public int AmountCommon { get; set; }
    public int AmountBfiSys { get; set; }
    public int AmountBfiAwe { get; set; }
    public int AmountFwi { get; set; }
    public int AmountWit { get; set; }
    public int AmountVisitor { get; set; }
    public IEnumerable<AddressStatistic>? AddressStatistics { get; set; } = [];
}