using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Webstore.Infrastructure.Querying
{
    public class Query<T,TKey>
    {
        public Query(Expression<Func<T, bool>> expression)
        {
            OrderByClauses = new List<OrderByClause<T,TKey>>();
            Predicate = expression;
        }

        public IList<OrderByClause<T, TKey>> OrderByClauses { get; set; }

        public Expression<Func<T, bool>> Predicate { get; set; }        

        public Query<T,TKey> OrderBy(OrderByClause<T, TKey> orderBy)
        {
            OrderByClauses.Add(orderBy);

            return this;
        }
    }
}
