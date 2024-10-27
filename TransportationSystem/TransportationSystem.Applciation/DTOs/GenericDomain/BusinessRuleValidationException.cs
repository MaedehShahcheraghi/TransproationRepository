using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Domain.GenericDomain
{
    public class BusinessRuleValidationException:Exception
    {
        public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Message)
        {

        }
    }
}
