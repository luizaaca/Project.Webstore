using System;
using NHibernate;
using Project.Webstore.Infrastructure.Querying;
using System.Collections.Generic;
using NHibernate.Criterion;
using System.Linq;

namespace Project.Webstore.Repository.Repositories
{
    public static class QueryTranslator
    {
        public static void TranslateIntoNHQuery<T, TKey>(this Query<T, TKey> query, IQueryable<T> nhQuery)
        {
            nhQuery = nhQuery.Where(query.Predicate);

            foreach (var orderByClause in query.OrderByClauses)
            {
                if (orderByClause.Desc)
                    nhQuery = nhQuery.OrderByDescending(orderByClause.OrderBy);
                else
                    nhQuery = nhQuery.OrderBy(orderByClause.OrderBy);
            }
        }
    }
}
