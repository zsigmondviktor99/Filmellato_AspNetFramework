﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//AutoMapper
using AutoMapper;
using Filmellato.Dtos;
using Filmellato.Models;

namespace Filmellato.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Rental, NewRentalDto>();

            //DTO to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipTypeDto, MembershipType>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<GenreDto, Genre>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<NewRentalDto, Rental>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}