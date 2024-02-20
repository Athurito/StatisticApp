using System.Text;

namespace Statistic.Application.Pdf.Extensions;

public static class PdfExtensions
{
    public static string ToHtml(this VisitorStatistic visitorStatistic)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine($"<tr><td>Allgemein</td><td class='right'>{visitorStatistic.AmountCommon}</td></tr>");
        sb.AppendLine($"<tr><td>Anwendungsentwickler(BFI)</td><td class='right'>{visitorStatistic.AmountBfiAwe}</td></tr>");
        sb.AppendLine($"<tr><td>Systemintegration(BFI)</td><td class='right'>{visitorStatistic.AmountBfiSys}</td></tr>");
        sb.AppendLine($"<tr><td>Informationstechniker(FWI)</td><td class='right'>{visitorStatistic.AmountFwi}</td></tr>");
        sb.AppendLine($"<tr><td>WirtschaftsInformatik(WIT)</td><td class='right'>{visitorStatistic.AmountWit}</td></tr>");
        
        return sb.ToString();
    }
}