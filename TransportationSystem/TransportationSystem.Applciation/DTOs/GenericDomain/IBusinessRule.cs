using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Domain.GenericDomain
{
    public interface IBusinessRule
    {
        bool HasValidRule();
        string Message { get; }
    }
}
