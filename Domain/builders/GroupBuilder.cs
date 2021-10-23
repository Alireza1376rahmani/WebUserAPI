using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.builders
{
    public class GroupBuilder : PrincipalBuilder<Group, GroupBuilder>
    {
        public override Group Build()
        {
            return new Group(id, name);
        }
    }
}
