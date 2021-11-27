using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationApp.Repository.Models
{
    public class APIResponse
    {
        public dynamic Data { get; set; }
        public string ResultCode { get; set; }
        public string ResultDescription { get; set; }
    }
}
