using Statistic.Domain.Enums;

namespace Statistic.Application.DTOs;

public class VisitorDto
{
    public DateTime CreateDate { get; set; }
    public AddressDto? AddressDto { get; init; }
    public bool[] VisitorInterests { get; init; } = new bool[Enum.GetNames(typeof(Interests)).Length];
    public bool[] VisitorAttentions { get; init; } = new bool[Enum.GetNames(typeof(Attentions)).Length];
}