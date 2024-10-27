using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Domain.GenericDomain
{
    public class ValueObject
    {
        protected static void CheckRule(IBusinessRule rule)
        {
            if (!rule.HasValidRule())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
