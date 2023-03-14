using Company.Application.Features.Company.Dtos;
using Core.Persistence.Repositories;

namespace Company.Application.Repositories;

public interface ICompanyRepository : IAsyncRepository<Domain.Entities.Company>
{
    Task UpdateIsActive(UpdateIsActiveDto updateIsActiveDto);
    Task OrderDateUpdate(OrderDateUpdateDto orderDateUpdateDto);
}