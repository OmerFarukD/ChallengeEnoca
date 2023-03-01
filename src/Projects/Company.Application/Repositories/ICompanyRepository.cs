using Core.Persistence.Repositories;

namespace Company.Application.Repositories;

public interface ICompanyRepository : IAsyncRepository<Domain.Entities.Company>
{
    
}