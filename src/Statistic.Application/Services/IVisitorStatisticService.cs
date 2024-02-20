using Statistic.Application.DTOs;
using Statistic.Application.Pdf;

namespace Statistic.Application.Services;

public interface IVisitorStatisticService
{
    public VisitorStatistic GetVisitorStatistic(IEnumerable<VisitorDto> visitors);
}