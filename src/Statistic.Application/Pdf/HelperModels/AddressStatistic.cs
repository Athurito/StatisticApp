using Statistic.Application.DTOs;

namespace Statistic.Application.Pdf.HelperModels;

public class AddressStatistic
{
    public int Amount { get; init; }
    public string? ZipCode { get; init; }
    public string? Town { get; init; }
}