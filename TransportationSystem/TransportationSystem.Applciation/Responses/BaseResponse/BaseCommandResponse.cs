using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.Responses.BaseResponse
{
    public class BaseCommandResponse
    {
        public long Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
