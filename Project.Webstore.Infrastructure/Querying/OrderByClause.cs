using System;
using System.Linq.Expressions;

namespace Project.Webstore.Infrastructure.Querying
{
    public class OrderByClause<T, TKey>
    {
        public OrderByClause(Expression<Func<T, TKey>> orderBy, bool desc)
        {
            OrderBy = orderBy;
            Desc = desc;
        }

        public bool Desc { get; private set; }
        public Expression<Func<T, TKey>> OrderBy { get; private set; }
    }
}
