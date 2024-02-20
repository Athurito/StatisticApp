using Statistic.Application.DTOs;

namespace Statistic.Application.Pdf;

public interface IPdfService
{
    public void CreatePdf(IEnumerable<VisitorDto> visitors, string directoryPath);
}