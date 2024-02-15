using Statistic.Domain.Entities;
using Statistic.Domain.Enums;

namespace Statistic.Application.DTOs;

public class VisitorDto
{
    public DateTime CreateDate { get; set; }
    public AddressDto AddressDto { get; set; }
    public bool[] VisitorInterests { get; set; } = new bool[Enum.GetNames(typeof(Interests)).Length];
    
   
}