using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.Responses.BaseResponse
{
    public class BaseRequestResponse<T> where T : class
    {
        public int ID { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> ErrorMessage { get; set; }
    }
}
