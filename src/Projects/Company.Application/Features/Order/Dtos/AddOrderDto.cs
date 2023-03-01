namespace Company.Application.Features.Order.Dtos;

public sealed class AddOrderDto
{
    public int CompanyId { get; set; }
    public int ProductId { get; set; }
    public string? CustomerName { get; set; }
    public DateTime OrderDate { get; set; }= DateTime.Now;
}