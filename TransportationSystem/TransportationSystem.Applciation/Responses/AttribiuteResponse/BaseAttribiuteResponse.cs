﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.Responses.AttribiuteResponse
{
    public class BaseAttribiuteResponse
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}
