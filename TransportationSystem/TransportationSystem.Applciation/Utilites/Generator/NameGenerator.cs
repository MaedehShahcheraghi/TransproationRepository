using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.Utilites.Generator
{
    public class NameGenerator
    {
        public static string GenerateUnicCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
