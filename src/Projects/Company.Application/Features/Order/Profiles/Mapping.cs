using AutoMapper;
using Company.Application.Features.Order.Dtos;
using Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Application.Features.Order.Profiles
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Order, AddOrderDto>().ForMember(s=>s.CompanyId,opt=>opt.MapFrom(c=>c.CompanyId)).ReverseMap();
        }
    }
}
