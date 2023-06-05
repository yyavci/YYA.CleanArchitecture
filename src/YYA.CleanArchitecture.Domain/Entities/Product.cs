using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Domain.Common;

namespace YYA.CleanArchitecture.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
    }
}
