using AutoMapper;
using Project.Webstore.Model.Product;
using Project.Webstore.Model.ProductAttributes.Interfaces;
using Project.Webstore.Services.ViewModels;
using Project.Webstore.Infrastructure.Helpers;
using Project.Webstore.Model.Category;

namespace Project.Webstore.Services
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductTitle, ProductSummaryView>()
                .ForMember(dest => dest.Price,
                    opt => opt.ResolveUsing<CurrencyResolver, decimal>(src => src.Price));

                cfg.CreateMap<ProductTitle, ProductView>()
                .ForMember(dest => dest.Price,
                    opt => opt.ResolveUsing<CurrencyResolver, decimal>(src => src.Price));

                cfg.CreateMap<Product, ProductSummaryView>()
                .ForMember(dest => dest.Price,
                    opt => opt.ResolveUsing<CurrencyResolver, decimal>(src => src.Price));

                cfg.CreateMap<Product, ProductSizeOption>();

                cfg.CreateMap<Category, CategoryView>();

                cfg.CreateMap<IProductAttribute, Refinement>();
            });
        }
    }

    public class CurrencyResolver : IMemberValueResolver<object, object, decimal, string>
    {
        public string Resolve(object source, object destination, decimal sourceMember, string destMember, ResolutionContext context)
        {
            return sourceMember.FormatMoney();
        }
    }
}
