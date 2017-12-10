using Project.Webstore.Services.ViewModels;
using System.Collections.Generic;

namespace Project.Webstore.Controllers.ViewModels.ProductCatalog
{
    public abstract class BaseProductCatalogPageView
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}
