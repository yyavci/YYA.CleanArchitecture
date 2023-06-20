using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYA.OnionArchitecture.Application.Wrappers
{
    public class Response
    {
        public Guid RequestId { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public bool Success { get; set; } = true;
    }
}
