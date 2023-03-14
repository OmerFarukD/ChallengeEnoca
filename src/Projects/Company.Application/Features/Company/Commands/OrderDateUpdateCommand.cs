using AutoMapper;
using Company.Application.Features.Company.Constants;
using Company.Application.Features.Company.Dtos;
using Company.Application.Repositories;
using MediatR;

namespace Company.Application.Features.Company.Commands;

public static class OrderDateUpdateCommand
{
    public record Command(OrderDateUpdateDto OrderDateUpdateDto) : IRequest<string>;
    
    public class Handler: IRequestHandler<Command,string>
    {
        private readonly ICompanyRepository _companyRepository;
       

        public Handler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

        }
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            await _companyRepository.OrderDateUpdate(request.OrderDateUpdateDto);
            return CompanyConstants.CompanyDateUpdateMessage;
        }
    }
}