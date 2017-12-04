using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Webstore.Infrastructure.Querying
{
    public enum CriteriaOperator
    {
        Equal,
        LesserThanOrEqual,
        HigherThanOrEqual,
        Lesser,
        Higher,
        NotApplicable
    }
}
