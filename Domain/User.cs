using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class User : Principal
    {
        public User(Guid id, string name) : base(id, name)
        {
            Guard.Ensures(() => name.Length > 2, nameof(name));
        }
        public User(Guid id, string name, List<Group> groups) : base(id, name, groups) { }
    }
}
