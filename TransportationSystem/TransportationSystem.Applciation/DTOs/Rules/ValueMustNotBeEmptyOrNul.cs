using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.GenericDomain;

namespace TransportationSystem.Domain.Entities.UserEntities.Rules
{
    public class ValueMustNotBeEmptyOrNul: IBusinessRule
    {
        private readonly string _value;
        public ValueMustNotBeEmptyOrNul(string value)
        {
            _value = value;
        }
        public bool HasValidRule()
        {
            var isValid = !string.IsNullOrEmpty(_value);
            return isValid;
        }
        public string Message => $"The value of {_value} must not be null or empty.";
    }
}
