using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Group : Principal
    {
        public Group(Guid id, string name) : base(id, name)
        {
        }
    }
}
