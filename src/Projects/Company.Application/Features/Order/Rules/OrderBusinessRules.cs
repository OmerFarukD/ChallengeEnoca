using Company.Application.Features.Order.Constants;
using Company.Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Company.Application.Features.Order.Rules;

public class OrderBusinessRules
{
    
    private readonly ICompanyRepository _companyRepository;

    public OrderBusinessRules(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    
    public async Task IsActiveRule(int companyId)
    {
        var  data = await _companyRepository.GetByFilter(x => x.Id == companyId);
        if (data.IsActive is false) throw new BusinessException(OrderConstants.OrderIsNotActive);
    }
    
    public async Task DatePermission(int companyId)
    {
        var company= await _companyRepository.GetByFilter(x => x.Id == companyId);
        if (DateTime.Now.Hour < company.DateTimeStart.Hour || DateTime.Now.Hour > company.DateTimeEnd.Hour)
            throw new BusinessException($"{DateTime.Now.Hour} : {DateTime.Now.Minute} zamanında sipariş alınamaz");
    }
    
}