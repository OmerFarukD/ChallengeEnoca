using Company.Application.Repositories;
using Compnay.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Compnay.Persistence.Repositories;

public class CompanyRepository :EfRepositoryBase<Company.Domain.Entities.Company,BaseDbContext> ,ICompanyRepository
{
    public CompanyRepository(BaseDbContext context) : base(context)
    {
    }
}