using Company.Domain.Entities;
using Core.Persistence.Repositories;

namespace Company.Application.Repositories;

public interface IProductRepository :IAsyncRepository<Product>
{
    
}