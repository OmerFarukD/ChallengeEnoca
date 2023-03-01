using AutoMapper;
using Company.Application.Features.Company.Dtos;

namespace Company.Application.Features.Company.Profiles;

public class Mapping :Profile
{
    public Mapping()
    {
        CreateMap<Domain.Entities.Company, CreateCompanyDto>().ReverseMap();
        CreateMap<Domain.Entities.Company, OrderDateUpdateDto>().ReverseMap();
        CreateMap<Domain.Entities.Company, UpdateIsActiveDto>().ReverseMap();
        CreateMap<Domain.Entities.Company, CompanyListDto>().ReverseMap();
    }
}