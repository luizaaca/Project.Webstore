using System.Collections.Generic;
using Project.Webstore.Services.ViewModels;

namespace Project.Webstore.Controllers.ViewModels.ProductCatalog
{
    public class HomePageView
    {
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
