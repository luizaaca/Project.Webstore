﻿using System;
using System.Linq.Expressions;

namespace Project.Webstore.Infrastructure.Querying
{
    public class Criterion
    {
        private string _propertyName;
        private object _value;
        private CriteriaOperator _criteriaOperator;

        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator)
        {
            _propertyName = propertyName;
            _value = value;
            _criteriaOperator = criteriaOperator;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public object Value
        {
            get { return _value; }
        }

        public CriteriaOperator CriteriaOperator
        {
            get { return _criteriaOperator; }
        }

        public static Criterion Create<T>(Expression<Func<T, object>> expression, object value, CriteriaOperator criteriaOperator)
        {
            string propertyName = PropertyNameHelper.ResolvePropertyName<T>(expression);

            return new Criterion(propertyName, value, criteriaOperator);
        }
    }
}