﻿using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<Example, ExampleDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<PhoneNumberType, PhoneNumberTypeDto>().ReverseMap();

            CreateMap<PersonPhone, PersonPhoneDto>().ReverseMap();
            CreateMap<PersonPhone, PersonPhoneRequest>().ReverseMap();
        }
    }
}
