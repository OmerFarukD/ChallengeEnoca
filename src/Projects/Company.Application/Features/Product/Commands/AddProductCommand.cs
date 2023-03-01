using AutoMapper;
using Company.Application.Features.Product.Constants;
using Company.Application.Features.Product.Dtos;
using Company.Application.Repositories;
using MediatR;

namespace Company.Application.Features.Product.Commands;

public static class AddProductCommand
{
    public record Command(AddProductDto AddProductDto) : IRequest<string>;
    
    public class Handler : IRequestHandler<Command,string>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public Handler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Domain.Entities.Product>(request.AddProductDto);

            await _productRepository.AddAsync(data);

            return ProductConstants.ProductAddedMessage;
            
        }
    }
}