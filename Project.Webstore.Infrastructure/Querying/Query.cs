using System.Collections.Generic;

namespace Project.Webstore.Infrastructure.Querying
{
    public class Query
    {
        private IList<Query> _subQueries = new List<Query>();
        private IList<Criterion> _criterias = new List<Criterion>();
        private IList<OrderByClause> _orderByClauses = new List<OrderByClause>();

        public IEnumerable<Criterion> Criteria
        {
            get { return _criterias; }
        }

        public IEnumerable<Query> SubQueries
        {
            get { return _subQueries; }
        }

        public IEnumerable<OrderByClause> OrderByClauses
        {
            get { return _orderByClauses; }
        }

        public void AddSubQuery(Query subQuery)
        {
            _subQueries.Add(subQuery);
        }

        public void AddCriteria(Criterion criteria)
        {
            _criterias.Add(criteria);
        }

        public void AddOrderByClause(OrderByClause orderByClause)
        {
            _orderByClauses.Add(orderByClause);
        }

        public QueryOperator QueryOperator { get; set; }
        public bool Not { get; set; }
    }
}
