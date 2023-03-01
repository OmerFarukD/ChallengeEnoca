using Core.Persistence.Repositories;

namespace Company.Domain.Entities;

public class Order : Entity
{

    public  Company? Company { get; set; }

    public int CompanyId { get; set; }
    public  Product? Product { get; set; }
   
    public int ProductId { get; set; }
    public string? CustomerName { get; set; }
    public DateTime OrderDate { get; set; }

}