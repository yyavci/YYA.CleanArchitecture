using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYA.CleanArchitecture.Application.Wrappers
{
    public class PagedResponse<T> : ServiceResponse<T>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public PagedResponse(T data , int pageSize , int pageNumber): base(data)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
