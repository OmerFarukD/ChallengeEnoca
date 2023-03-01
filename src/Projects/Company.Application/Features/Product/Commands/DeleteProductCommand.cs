using AutoMapper;
using Company.Application.Features.Product.Constants;
using Company.Application.Repositories;
using MediatR;

namespace Company.Application.Features.Product.Commands;

public static class DeleteProductCommand
{
    public record Command(int Id) : IRequest<string>;
    
    public class Handler :IRequestHandler<Command,string>
    {
        private readonly IProductRepository _productRepository;

        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(request.Id);

            return ProductConstants.ProductDeletedMessage;
        }
    }
}