using Project.Webstore.Services.Messaging.ProductCatalogService.Request;
using System.Collections.Generic;

namespace Project.Webstore.UI.Web.MVC.ViewModels.JsonDTOs
{
    public class JsonProductSearchRequest
    {
        public int CategoryId { get; set; }
        public ProductsSortBy SortBy { get; set; }
        public IEnumerable<JsonRefinementGroup> RefinementGroups { get; set; }
        public int PageIndex { get; set; }
    }
}