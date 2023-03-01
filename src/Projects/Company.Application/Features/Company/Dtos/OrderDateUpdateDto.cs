namespace Company.Application.Features.Company.Dtos;

public class OrderDateUpdateDto
{
    public int Id { get; set; }
    public DateTime DateTimeStart { get; set; }
    public DateTime DateTimeEnd { get; set; }
}