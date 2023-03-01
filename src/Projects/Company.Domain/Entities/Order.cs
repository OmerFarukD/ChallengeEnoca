using Core.Persistence.Repositories;

namespace Company.Domain.Entities;

public class Order : Entity
{

    public virtual Company Company { get; set; }
    public virtual Product Product { get; set; }
    public int CompanyId { get; set; }
    public int ProductId { get; set; }
    public string? CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
}