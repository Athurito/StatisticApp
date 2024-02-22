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
        
        sb.AppendLine("<h1>Informatik Campus Wiesau - Besucherstatistik Infotag</h1>");
        sb.AppendLine($"<h1>{CurrentDate}</h1>");
        sb.AppendLine("<br>");
        sb.AppendLine($"<span><label>Besucheranzahl</label></span> <span><label>{statistic.AmountVisitor}</label></span>");
        
        sb.AppendLine(statistic.ToHtml());
        sb.AppendLine(statistic.AddressStatistics!.ToHtml());

        return sb.ToString();
    }
    
    
    
    private static string GetHeader()
    {
        return @"
            <html>
                <head>
                    <link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css' integrity='sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T' crossorigin='anonymous'>
                    <style>
                        h1 { font-size: 25px;
                             margin-bottom:20px;
                             text-align: center;}
                        h2 { font-size: 16px; }
                        table {
                            width: 100%;
                            font-size: 15px;
                        }
                        p { font-size: 10px; }
                        label {
                            font-size: 20px;
                        }
                        @page {
                            @top-left {
                                content: ''
                            }
                            @top-center {
                                content: '';
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