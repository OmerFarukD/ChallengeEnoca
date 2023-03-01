using Core.Persistence.Repositories;

namespace Company.Domain.Entities;

public class Product :Entity
{

    public virtual Company Company { get; set; }
    public int CompanyId { get; set; }
    
    public string? ProductName { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
}