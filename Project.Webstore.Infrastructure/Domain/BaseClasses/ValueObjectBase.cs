using Project.Webstore.Infrastructure.UnitOfWork.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Webstore.Infrastructure.UnitOfWork.BaseClasses
{
    public abstract class ValueObjectBase
    {
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();

        public ValueObjectBase() { }

        protected abstract void Validate();

        public void ThrowExceptionIfInvalid()
        {
            _brokenRules.Clear();
            Validate();
            if(_brokenRules.Count() > 0)
            {
                StringBuilder issues = new StringBuilder();
                foreach (var businessRule in _brokenRules)
                {
                    issues.AppendLine(businessRule.Rule);
                }

                throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }
    }
}
