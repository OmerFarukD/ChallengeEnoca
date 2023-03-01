using Core.Persistence.Repositories;

namespace Company.Domain.Entities;

public class Company :Entity
{
    public string? CompanyName { get; set; }
    public bool IsActive { get; set; }
    public  DateTime DateTimeStart { get; set; }
    public  DateTime DateTimeEnd { get; set; }

    public virtual ICollection<List<Product>> Products { get; set; }
}