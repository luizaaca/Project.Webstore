using AutoMapper;
using Project.Webstore.Model.Category;
using Project.Webstore.Services.ViewModels;
using System.Collections.Generic;

namespace Project.Webstore.Services.Mapping
{
    public static class CategoryMapper
    {
        public static IEnumerable<CategoryView> ToCategoryViews(this IEnumerable<Category> categories)
            => Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryView>>(categories);
    }
}
