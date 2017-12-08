using System;
using System.Linq.Expressions;

namespace Project.Webstore.Infrastructure.Querying
{
    public class OrderByClause<T>
    {
        public OrderByClause(Expression<Func<T, object>> orderBy, bool desc)
        {
            OrderBy = orderBy;
            Desc = desc;
        }

        public bool Desc { get; private set; }
        public Expression<Func<T, object>> OrderBy { get; private set; }
    }
}
