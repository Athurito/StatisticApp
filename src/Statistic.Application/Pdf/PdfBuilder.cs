using System.Text;
using Statistic.Application.Pdf.Extensions;

namespace Statistic.Application.Pdf;

internal static class PdfBuilder
{
    private static readonly string CurrentDate = DateTime.Now.ToString("dd MMMM yyyy");
    private static readonly string CurrentTimestamp = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
    
    internal static string BuildPdf(VisitorStatistic statistic)
    {
        var sb = new StringBuilder();

        sb.Append(GetHeader());

        sb.AppendLine("<table class='table table-striped table-bordered table-sm'>");
        sb.AppendLine("<thead class='thead-dark'>");
        sb.AppendLine("<tr><th>Kategorie</th><th>Anzahl</th></tr>");
        sb.AppendLine("</thead>");
        sb.AppendLine("<tbody>");
        sb.AppendLine(statistic.ToHtml());
        
        sb.AppendLine("</tbody>");
        sb.AppendLine("</table>");

        return sb.ToString();
    }
    
    
    
    private static string GetHeader()
    {
        return @"
            <html>
                <head>
                    <link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css' integrity='sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T' crossorigin='anonymous'>
                    <style>
                        h1 { font-size: 18px; }
                        h2 { font-size: 16px; }

                        table {
                            width: 100%;
                            font-size: 10px;
                        }
                        p { font-size: 10px; }
                        label {
                            font-size: 10px;
                        }
                        @page {
                            @top-left {
                                content: ''
                            }
                            @top-center {
                                content: 'Informatik Campus Wiesau - Besucherstatistik Infotag " + CurrentDate + @"';
                            }
                            @top-right {
                               content: '';
                            }
                            @bottom-left {
                                content: 'Stand: " + CurrentTimestamp + @"';
                            }
                            @bottom-center {
                                content: '';
                            }
                            @bottom-right {
                                content: 'Seite ' counter(page) ' von ' counter(pages);
                            }
                        }
                    </style>
                </head>
            <body>";
    }
}