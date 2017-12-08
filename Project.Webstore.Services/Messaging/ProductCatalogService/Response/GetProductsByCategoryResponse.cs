using Project.Webstore.Services.ViewModels;
using System.Collections.Generic;

namespace Project.Webstore.Services.Messaging.ProductCatalogService.Response
{
    public class GetProductsByCategoryResponse
    {
        public string SelectedCategoryName { get; set; }
        public int SelectedCategory { get; set; }

        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }
        public int NumberOfTitlesFound { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }

        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
