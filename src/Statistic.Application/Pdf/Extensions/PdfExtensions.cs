using System.Text;
using Statistic.Application.DTOs;
using Statistic.Application.Pdf.HelperModels;

namespace Statistic.Application.Pdf.Extensions;

public static class PdfExtensions
{
    public static string ToHtml(this VisitorStatistic visitorStatistic)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("<table class='table table-striped table-bordered table-sm'>");
        sb.AppendLine("<thead class='thead-dark'>");
        sb.AppendLine("<tr><th>Kategorie</th><th>Anzahl</th></tr>");
        sb.AppendLine("</thead>");
        sb.AppendLine("<tbody>");
        sb.AppendLine($"<tr><td>Allgemein</td><td class='right'>{visitorStatistic.AmountCommon}</td></tr>");
        sb.AppendLine($"<tr><td>Anwendungsentwickler(BFI)</td><td class='right'>{visitorStatistic.AmountBfiAwe}</td></tr>");
        sb.AppendLine($"<tr><td>Systemintegration(BFI)</td><td class='right'>{visitorStatistic.AmountBfiSys}</td></tr>");
        sb.AppendLine($"<tr><td>Informationstechniker(FWI)</td><td class='right'>{visitorStatistic.AmountFwi}</td></tr>");
        sb.AppendLine($"<tr><td>WirtschaftsInformatik(WIT)</td><td class='right'>{visitorStatistic.AmountWit}</td></tr>");
        sb.AppendLine("</tbody>");
        sb.AppendLine("</table>");
        return sb.ToString();
    }
    
    public static string ToHtml(this IEnumerable<AddressStatistic> addressStatistics)
    {
        var sb = new StringBuilder();
        sb.AppendLine("<table class='table table-striped table-bordered table-sm'>");
        sb.AppendLine("<thead class='thead-dark'>");
        sb.AppendLine("<tr><th>Postleitzahl</th><th>Ort</th><th>Anzahl</th></tr>");
        sb.AppendLine("</thead>");
        sb.AppendLine("<tbody>");
        foreach (var address in addressStatistics)
        {
            sb.AppendLine($"<tr><td>{address.ZipCode}</td><td>{address.Town}</td><td>{address.Amount}</td></tr>");
        }
        sb.AppendLine("</tbody>");
        sb.AppendLine("</table>");
        
        return sb.ToString();
    }
}