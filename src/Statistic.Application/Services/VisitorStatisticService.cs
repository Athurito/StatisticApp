using Statistic.Application.DTOs;
using Statistic.Application.Pdf;
using Statistic.Domain.Entities;
using Statistic.Domain.Enums;

namespace Statistic.Application.Services;

public class VisitorStatisticService : IVisitorStatisticService
{
    public VisitorStatistic GetVisitorStatistic(IEnumerable<VisitorDto> visitors)
    {
        var visitorStatistic = new VisitorStatistic();
        foreach (var visitor in visitors)
        {
            var interests = CovertBoolToInterest(visitor.VisitorInterests);
            foreach (var interest in interests)
            {
                switch (interest.Interest)
                {
                    case Interests.Common:
                        visitorStatistic.AmountCommon++;
                        break;
                    case Interests.Sy:
                        visitorStatistic.AmountBfiSys++;
                        break;
                    case Interests.Bfi:
                        visitorStatistic.AmountBfiAwe++;
                        break;
                    case Interests.Fwi:
                        visitorStatistic.AmountFwi++;
                        break;
                    case Interests.Wit:
                        visitorStatistic.AmountWit++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            visitorStatistic.AmountVisitor++;
        }

        return visitorStatistic;
    }
    
    private static List<VisitorInterests> CovertBoolToInterest(IReadOnlyList<bool> array)
    {
        var interests = new List<VisitorInterests>();
        for (var i = 0; i < array.Count; i++)
        {
            if (!array[i]) continue;
            
            var interest = new VisitorInterests
            {
                VisitorId = Guid.Empty,
                Interest = (Interests)i
            };
            interests.Add(interest);
        }
        return interests;
    }
}