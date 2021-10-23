using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class User : Principal
    {
        public PartyRef Party { get; private set; }

        public User(Guid id, string name,Party party) : base(id, name)
        {
            //    Guard.Ensures(() => name.Length > 2, nameof(name));
            if(party != null)
                Party = new PartyRef(party.Id, DateTime.Now);
        }

        public void AssignParty(Party party)
        {
            this.Party = new PartyRef(party.Id, DateTime.Now);
        }

    }
}
