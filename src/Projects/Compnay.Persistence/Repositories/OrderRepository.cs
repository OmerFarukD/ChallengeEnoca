using Company.Application.Repositories;
using Company.Domain.Entities;
using Compnay.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Compnay.Persistence.Repositories;

public class OrderRepository : EfRepositoryBase<Order,BaseDbContext>,IOrderRepository
{
    public OrderRepository(BaseDbContext context) : base(context)
    {
    }
}