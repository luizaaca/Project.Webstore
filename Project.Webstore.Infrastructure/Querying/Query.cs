using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Webstore.Infrastructure.Querying
{
    public class Query<T>
    {
        public Query(Expression<Func<T, bool>> expression)
        {
            OrderByClauses = new List<OrderByClause<T>>();
            Predicate = expression;
        }

        public IList<OrderByClause<T>> OrderByClauses { get; set; }

        public Expression<Func<T, bool>> Predicate { get; set; }        

        public Query<T> OrderBy(OrderByClause<T> orderBy)
        {
            OrderByClauses.Add(orderBy);

            return this;
        }
    }
}
