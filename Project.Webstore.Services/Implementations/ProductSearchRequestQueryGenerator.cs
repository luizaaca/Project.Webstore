﻿using Project.Webstore.Infrastructure.Querying;
using Project.Webstore.Model.Product;
using Project.Webstore.Services.Messaging.ProductCatalogService.Request;
using System;
using System.Linq;

namespace Project.Webstore.Services.Implementations
{
    public class ProductSearchRequestQueryGenerator
    {
        public static Query<Product> CreateQueryFor(GetProductsByCategoryRequest request)
        {
            var colorIds = request.ColorIds;
            var brandIds = request.BrandIds;
            var sizeIds = request.SizeIds;
            OrderByClause<Product> orderBy = null;

            switch (request.SortBy)
            {
                case ProductsSortBy.PriceHighToLow:
                    orderBy = new OrderByClause<Product>(p => p.Price, true);
                    break;
                default:
                    orderBy = new OrderByClause<Product>(p => p.Price, false);
                    break;
            }

            return new Query<Product>(p =>
                p.Category.Id == request.CategoryId &&
                (colorIds.Length == 0 || colorIds.Contains(p.Color.Id)) &&
                (brandIds.Length == 0 || brandIds.Contains(p.Brand.Id)) &&
                (sizeIds.Length == 0 || sizeIds.Contains(p.Size.Id))).OrderBy(orderBy);
        }
    }
}
