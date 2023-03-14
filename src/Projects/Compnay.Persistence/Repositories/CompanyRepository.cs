using Company.Application.Features.Company.Dtos;
using Company.Application.Repositories;
using Compnay.Persistence.Contexts;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Compnay.Persistence.Repositories;

public class CompanyRepository :EfRepositoryBase<Company.Domain.Entities.Company,BaseDbContext> ,ICompanyRepository
{
    public CompanyRepository(BaseDbContext context) : base(context)
    {
        
    }

    public async Task UpdateIsActive(UpdateIsActiveDto updateIsActiveDto)
    {
        var company =await GetByFilter(x => x.Id == updateIsActiveDto.Id);

        if (company is null)
            throw new BusinessException($"{updateIsActiveDto.Id} id ye ait şirket bulunamadı.");
        
        company.IsActive = updateIsActiveDto.IsActive;

        await Context.SaveChangesAsync();
    }

    public async Task OrderDateUpdate(OrderDateUpdateDto orderDateUpdateDto)
    {
        var company =await GetByFilter(x => x.Id == orderDateUpdateDto.Id);

        if (company is null)
            throw new BusinessException($"{orderDateUpdateDto.Id} id ye ait şirket bulunamadı.");

        company.DateTimeStart = orderDateUpdateDto.DateTimeStart;
        company.DateTimeEnd = orderDateUpdateDto.DateTimeEnd;
    }
}