using Company.Application.Repositories;
using Company.Domain.Entities;
using Compnay.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Compnay.Persistence.Repositories;

public class ProductRepository : EfRepositoryBase<Product,BaseDbContext>, IProductRepository
{
    public ProductRepository(BaseDbContext context) : base(context)
    {

    }
}