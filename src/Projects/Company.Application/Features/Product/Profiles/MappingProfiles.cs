using AutoMapper;
using Company.Application.Features.Product.Dtos;

namespace Company.Application.Features.Product.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
    
        CreateMap<Domain.Entities.Product, AddProductDto>()
            .ForMember(d=>d.CompanyId,opt=>opt.MapFrom(c=>c.Company.Id))
            .ReverseMap();
        
        CreateMap<Domain.Entities.Product, UpdateProductDto>()
            .ForMember(d=>d.CompanyId,opt=>opt.MapFrom(c=>c.Company.Id))
            .ReverseMap();
        
        CreateMap<Domain.Entities.Product, GetProductListDto>()
            .ForMember(d=>d.CompanyId,opt=>opt.MapFrom(c=>c.Company.Id))
            .ReverseMap();
        
    }
}