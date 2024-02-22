using System.Diagnostics;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using Statistic.Application.DTOs;
using Statistic.Application.Services;

namespace Statistic.Application.Pdf;

public class PdfService : IPdfService
{
    private readonly IVisitorStatisticService _statisticService;

    public PdfService(IVisitorStatisticService statisticService)
    {
        _statisticService = statisticService;
    }
    
    public void CreatePdf(IEnumerable<VisitorDto> visitors, string directoryPath)
    {
        var fileName = CreateFileName();
        var filePath = directoryPath + fileName;
        var visitorStatistic = _statisticService.GetVisitorStatistic(visitors.ToList()); 
        
        var pdfString = PdfBuilder.BuildPdf(visitorStatistic);
       
        ConvertToPdf(pdfString,filePath);
        OpenPdf(filePath);
    }
    private static void ConvertToPdf(string html, string fileName)
    {
        using var pdf = new PdfWriter(fileName);
        HtmlConverter.ConvertToPdf(html, pdf);
    }
    
    private static string CreateFileName()
    {
        return "\\Statistic " + DateTime.Now.ToString("dd.MM.yyyy-HH.mm-ss") + ".pdf";
    }
    
    private static void OpenPdf(string filePath)
    {
        ProcessStartInfo startInfo = new(filePath)
        {
            UseShellExecute = true
        };
        Process.Start(startInfo);
    }
}