using AutoMapper;
using Company.Application.Features.Company.Constants;
using Company.Application.Features.Company.Dtos;
using Company.Application.Repositories;
using MediatR;

namespace Company.Application.Features.Company.Commands;

public static class IsActiveUpdateCommand
{
    public record Command(UpdateIsActiveDto UpdateIsActiveDto) : IRequest<string>;
    
    public class Handler: IRequestHandler<Command,string>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public Handler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Domain.Entities.Company>(request.UpdateIsActiveDto);
            
            await _companyRepository.UpdateAsync(data);
            
            return CompanyConstants.CompanyIsActiveUpdateMessage;
        }
        
    }
    
}