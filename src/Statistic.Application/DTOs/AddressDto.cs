using Statistic.Domain.Entities;

namespace Statistic.Application.DTOs;

public class AddressDto
{
    public int Id { get; set; }
    public string? ZipCode { get; set; }
    public string? Town { get; set; }
}