using AutoMapper;
using Company.Application.Features.Order.Constants;
using Company.Application.Features.Order.Dtos;
using Company.Application.Features.Order.Rules;
using Company.Application.Repositories;
using MediatR;

namespace Company.Application.Features.Order.Commands;

public static class AddOrderCommand
{
    public record Command(AddOrderDto AddOrderDto) : IRequest<string>;
    public class Handler :IRequestHandler<Command,string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly OrderBusinessRules _orderBusinessRules;

        public Handler(IOrderRepository orderRepository, IMapper mapper, OrderBusinessRules orderBusinessRules)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderBusinessRules = orderBusinessRules;
        }

        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Domain.Entities.Order>(request.AddOrderDto);
           
            await _orderBusinessRules.IsActiveRule(data.CompanyId);
            
            await _orderBusinessRules.DatePermission(data.CompanyId);

            await _orderRepository.AddAsync(data);
            
            return OrderConstants.OrderAdded;
        }
    }
}