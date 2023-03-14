using AutoMapper;
using Company.Application.Features.Product.Commands;
using Company.Application.Features.Product.Dtos;
using Company.Application.Repositories;
using MediatR;

namespace Company.Application.Features.Product.Queries;

public static class GetProductListQuery
{
    public record Query : IRequest<List<GetProductListDto>>;
    
    public class Handler : IRequestHandler<Query,List<GetProductListDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        
        public Handler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        
        public async Task<List<GetProductListDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetAllAsync();

            return _mapper.Map<List<GetProductListDto>>(data);
        }
        
    }
    
}