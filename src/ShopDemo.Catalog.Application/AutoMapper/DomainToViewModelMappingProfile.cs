using AutoMapper;
using ShopDemo.Catalog.Application.ViewModels;
using ShopDemo.Catalog.Domain.Entities;

namespace ShopDemo.Catalog.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(d => d.Height, o => o.MapFrom(s => s.Dimensions.Height))
                .ForMember(d => d.Width, o => o.MapFrom(s => s.Dimensions.Width))
                .ForMember(d => d.Depth, o => o.MapFrom(s => s.Dimensions.Depth));

            CreateMap<Category, CategoryViewModel>();
        }
    }
}
