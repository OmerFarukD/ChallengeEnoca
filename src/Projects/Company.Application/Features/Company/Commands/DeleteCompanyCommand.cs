using AutoMapper;
using Company.Application.Features.Company.Constants;
using Company.Application.Repositories;
using MediatR;

namespace Company.Application.Features.Company.Commands;

public static class DeleteCompanyCommand
{
    public record Command(int Id) : IRequest<string>;
    
    public class Handler: IRequestHandler<DeleteCompanyCommand.Command,string>
    {
        private readonly ICompanyRepository _companyRepository;

        public Handler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            await _companyRepository.DeleteAsync(request.Id);
            return CompanyConstants.CompanyDeletedMessage;
            
        }
    }
}