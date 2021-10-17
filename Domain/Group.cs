using System;
using System.Collections.Generic;

namespace Domain
{
    public class Group : Principal
    {
            public Group(Guid id, string name) : base(id, name) { }
       // public Group(Guid id, string name, List<Group> groups) : base(id, name, groups) { }
    }
}
