using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.builders
{
    public class UserBuilder : PrincipalBuilder<User, UserBuilder>
    {

        private Party Party = null;

        public UserBuilder WithParty(Party party)
        {
            Party = party;
            return this;
        }

        public override User Build()
        {
            return new User(id, name,Party);
        }
    }
}
