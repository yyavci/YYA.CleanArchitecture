using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYA.CleanArchitecture.Application.Wrappers
{
    public class ServiceResponse<T> : Response
    {
        public T Data { get; set; }

        public ServiceResponse(T data)
        {
            Data = data;
        }
    }
}
