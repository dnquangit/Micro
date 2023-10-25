﻿using AutoMapper;
using Product.API.Entities;
using Shared.Dtos.Products;
using Infras.Mappings;

namespace Product.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogProduct, ProductDto>();
            CreateMap<CreateProductDto, CatalogProduct>(); // .ReverseMap()
            CreateMap<UpdateProductDto, CatalogProduct>()
                .IgnoreAllNonExisting();

        }
    }
}
