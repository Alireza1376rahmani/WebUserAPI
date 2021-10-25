using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.builders
{
    public class UserBuilder : PrincipalBuilder<User, UserBuilder>
    {

        private Guid Party = Guid.Empty;

        public UserBuilder WithParty(Guid partyId)
        {
            Party = partyId;
            return this;
        }

        public override User Build()
        {
            return new User(id, name,Party);
        }
    }
}
