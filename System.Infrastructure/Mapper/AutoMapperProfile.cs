using System.Domain.Entities;
using System.Infrastructure.Models;
using AutoMapper;

namespace System.Infrastructure.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category1Entity, Category1Model>()
                .ForMember(d => d.ID, map => map.MapFrom(s => s.Cat1ID))
                .ForMember(d => d.Code, map => map.MapFrom(s => s.Cat1Code))
                .ForMember(d => d.Description, map => map.MapFrom(s => s.Cat1Desc))
                .ForMember(d => d.Image, map => map.MapFrom(s => s.Cat1Img))
                .ForMember(d => d.RowVersion, map => map.MapFrom(s => s.RowVersion))
                .ReverseMap();

            CreateMap<Category2Entity, Category2Model>()
                .ForMember(d => d.ID, map => map.MapFrom(s => s.Cat2ID))
                .ForMember(d => d.Code, map => map.MapFrom(s => s.Cat2Code))
                .ForMember(d => d.Description, map => map.MapFrom(s => s.Cat2Desc))
                .ForMember(d => d.Image, map => map.MapFrom(s => s.Cat2Img))
                .ForMember(d => d.Cat1ID, map => map.MapFrom(s => s.Cat1ID))
                .ForMember(d => d.Cat1Description, map => map.MapFrom(s => s.Category1.Cat1Desc))
                .ForMember(d => d.RowVersion, map => map.MapFrom(s => s.RowVersion))
                .ReverseMap();

            CreateMap<Category3Entity, Category3Model>()
                .ForMember(d => d.ID, map => map.MapFrom(s => s.Cat3ID))
                .ForMember(d => d.Code, map => map.MapFrom(s => s.Cat3Code))
                .ForMember(d => d.Description, map => map.MapFrom(s => s.Cat3Desc))
                .ForMember(d => d.Image, map => map.MapFrom(s => s.Cat3Img))
                .ForMember(d => d.Cat2ID, map => map.MapFrom(s => s.Cat2ID))
                .ForMember(d => d.Cat2Description, map => map.MapFrom(s => s.Category2.Cat2Desc))
                .ForMember(d => d.RowVersion, map => map.MapFrom(s => s.RowVersion))
                .ReverseMap();

            CreateMap<ProductEntity, ProductModel>()
                .ForMember(d => d.ID, map => map.MapFrom(s => s.ProdID))
                .ForMember(d => d.Code, map => map.MapFrom(s => s.ProdCode))
                .ForMember(d => d.ShortDesc, map => map.MapFrom(s => s.ShortDesc))
                .ForMember(d => d.LongDesc, map => map.MapFrom(s => s.LongDesc))
                .ForMember(d => d.Cat3ID, map => map.MapFrom(s => s.Cat3ID))
                .ForMember(d => d.MinStock, map => map.MapFrom(s => s.MinStock))
                .ForMember(d => d.MaxStock, map => map.MapFrom(s => s.MaxStock))
                .ForMember(d => d.Cost, map => map.MapFrom(s => s.Cost))
                .ForMember(d => d.MarkupAmount, map => map.MapFrom(s => s.MarkupAmount))
                .ForMember(d => d.MarkupPercent, map => map.MapFrom(s => s.MarkupPercent))
                .ForMember(d => d.Price, map => map.MapFrom(s => s.Price))
                .ForMember(d => d.Vatable, map => map.MapFrom(s => s.Vatable))
                .ForMember(d => d.Barcode, map => map.MapFrom(s => s.Barcode))
                .ForMember(d => d.Stock, map => map.MapFrom(s => s.Stock))
                .ForMember(d => d.Active, map => map.MapFrom(s => s.Active))
                .ForMember(d => d.Cat3Description, map => map.MapFrom(s => s.Category3.Cat3Desc))
                .ForMember(d => d.RowVersion, map => map.MapFrom(s => s.RowVersion))
                .ReverseMap();
        }
    }
}