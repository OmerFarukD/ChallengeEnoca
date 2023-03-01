using AutoMapper;
using Company.Application.Features.Company.Dtos;
using Company.Application.Repositories;
using MediatR;

namespace Company.Application.Features.Company.Queries;

public static class GetCompanyListQuery
{
    public record Query : IRequest<List<CompanyListDto>>;
    
    public class Handler :IRequestHandler<Query, List<CompanyListDto>>
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public Handler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<List<CompanyListDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var data = await _companyRepository.GetAllAsync();

           return _mapper.Map<List<CompanyListDto>>(data); 
        }
    }
}