using Core.Persistence.Repositories;

namespace Company.Domain.Entities;

public class Product :Entity
{

    public  Company Company { get; set; }
    public int CompanyId { get; set; }
    
    public string? ProductName { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
}