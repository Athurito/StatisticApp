namespace Statistic.Application.DTOs;

public class AddressDto
{
    public int Id { get; init; }
    public string? ZipCode { get; set; }
    public string? Town { get; set; }
    
    public override string ToString()
    {
        return ZipCode + " " + Town;
    }
}