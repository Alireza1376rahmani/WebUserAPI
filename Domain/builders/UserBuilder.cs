using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.builders
{
    class UserBuilder : PrincipalBuilder<User, UserBuilder>
    {
        public override User Build()
        {
            return new User(id, name);
        }
    }
}
