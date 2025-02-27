﻿using AutoMapper;
using MongoDbFoodMart.Dtos.CategoryDtos;
using MongoDbFoodMart.Dtos.DiscountDtos;
using MongoDbFoodMart.Dtos.FeatureDtos;
using MongoDbFoodMart.Dtos.ProductDtos;
using MongoDbFoodMart.Dtos.SellingDtos;
using MongoDbFoodMart.Entities;

namespace MongoDbFoodMart.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIDFeatureDto>().ReverseMap();

            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetByIDDiscountDto>().ReverseMap();

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIDCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIDProductDto>().ReverseMap();

            CreateMap<Selling, ResultSellingDto>().ReverseMap();
            CreateMap<Selling, CreateSellingDto>().ReverseMap();
            CreateMap<Selling, UpdateSellingDto>().ReverseMap();
            CreateMap<Selling, GetByIDSellingDto>().ReverseMap();


            CreateMap<Product, ResultProductWithCategoryDto>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.Name));
            CreateMap<Selling, ResultSellingWithProductDto>()
     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
     .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
     .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl));

        }
    }
}
