namespace Company.Application.Features.Product.Dtos;

public class GetProductListDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string? ProductName { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
}