using System.Collections.Generic;
using AutoMapper;
using Project.Webstore.Model.Product;
using Project.Webstore.Services.ViewModels;

namespace Project.Webstore.Services.Mapping
{
    public static class ProductTitleMapper
    {
        public static IEnumerable<ProductSummaryView> ToProductSummaryView(this IEnumerable<ProductTitle> products)
            => Mapper.Map<IEnumerable<ProductTitle>, IEnumerable<ProductSummaryView>>(products);

        public static ProductView ToProductView(this ProductTitle product)
            => Mapper.Map<ProductTitle, ProductView>(product);
    }
}
