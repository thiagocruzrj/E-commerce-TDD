using AutoMapper;
using ShopDemo.Catalog.Application.ViewModels;
using ShopDemo.Catalog.Domain.Entities;

namespace ShopDemo.Catalog.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>()
                .ConstructUsing(p =>
                    new Product(p.CategoryId, p.Name, p.Description,
                        p.Active, p.Value, p.RegisterDate,
                        p.Image, new Dimensions(p.Height, p.Width, p.Depth)));

            CreateMap<CategoryViewModel, Category>()
                .ConstructUsing(c => new Category(c.Name, c.Code));
        }
    }
}
