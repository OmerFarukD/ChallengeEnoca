using Company.Application.Features.Order.Constants;
using Company.Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Company.Application.Features.Order.Rules;

public class OrderBusinessRules
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderBusinessRules(ICompanyRepository companyRepository, IOrderRepository orderRepository)
    {
        _companyRepository = companyRepository;
        _orderRepository = orderRepository;
    }

    public async Task IsActiveRule(int companyId)
    {
        var data = await _companyRepository.GetByFilter(x => x.Id == companyId);
        if (data.IsActive is false) throw new BusinessException(OrderConstants.OrderIsNotActive);
    }

    public async Task DatePermission(int companyId, int orderId)
    {
        var company= await _companyRepository.GetByFilter(x => x.Id == companyId);
        var order = await _orderRepository.GetByFilter(x => x.Id == orderId);

        if (order.OrderDate < company.DateTimeStart && order.OrderDate > company.DateTimeEnd)
            throw new BusinessException($"{order.OrderDate} zamanında sipariş alınamaz");
    }
}