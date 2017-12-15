using System.Collections.Generic;
using System.Linq;
using Project.Webstore.Model.Product;
using Project.Webstore.Services.Messaging.ProductCatalogService.Request;
using Project.Webstore.Services.Messaging.ProductCatalogService.Response;
using Project.Webstore.Services.ViewModels;

namespace Project.Webstore.Services.Mapping
{
    public static class ProductMapper
    {
        public static GetProductsByCategoryResponse CreateResultFrom(
            this IEnumerable<Product> products,
            GetProductsByCategoryRequest request)
        {
            var result = new GetProductsByCategoryResponse();

            var titlesFound = products.Select(p => p.Title).Distinct();

            result.SelectedCategory = request.CategoryId;

            result.NumberOfTitlesFound = titlesFound.Count();

            result.TotalNumberOfPages = NoOfResultPagesGiven(request.NumberOfResultsPerPage, result.NumberOfTitlesFound);

            result.RefinementGroups = GenerateAvailableProductRefinementsFrom(titlesFound);

            result.Products = CropProductListToSatisfyGivenIndex(request.PageIndex, request.NumberOfResultsPerPage, titlesFound);

            result.CurrentPage = request.PageIndex;

            return result;
        }

        private static IEnumerable<ProductSummaryView> CropProductListToSatisfyGivenIndex(int pageIndex, int numberOfResultsPerPage, IEnumerable<ProductTitle> titlesFound)
        {
            if(pageIndex > 1)
            {
                int skip = (pageIndex - 1) * numberOfResultsPerPage;
                return titlesFound.Skip(skip).Take(numberOfResultsPerPage).ToProductSummaryView();
            }
            else
            {
                return titlesFound.Take(numberOfResultsPerPage).ToProductSummaryView();
            }
        }

        private static IEnumerable<RefinementGroup> GenerateAvailableProductRefinementsFrom(IEnumerable<ProductTitle> titlesFound)
        {
            var brandsRefinementGroup = titlesFound.
                Select(p => p.Brand).Distinct().ToRefinementGroup(RefinementGroupings.brand);

            var colorsRefinementGroup = titlesFound.
                Select(p => p.Color).Distinct().ToRefinementGroup(RefinementGroupings.color);

            var sizesRefinementGroup = (from t in titlesFound
                                        from p in t.Products
                                        select p.Size).Distinct().ToRefinementGroup(RefinementGroupings.size);

            var refinementGroups = new List<RefinementGroup>();

            refinementGroups.Add(brandsRefinementGroup);
            refinementGroups.Add(colorsRefinementGroup);
            refinementGroups.Add(sizesRefinementGroup);

            return refinementGroups;
        }

        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfTitlesFound)
        {
            if (numberOfTitlesFound < numberOfResultsPerPage)
                return 1;
            else
                return (numberOfTitlesFound / numberOfResultsPerPage) + ((numberOfTitlesFound % numberOfResultsPerPage) > 0 ? 1 : 0);
        }
    }
}
