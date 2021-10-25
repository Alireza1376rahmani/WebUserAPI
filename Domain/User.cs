using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class User : Principal
    {
        public PartyRef Party { get; private set; }

        public User(Guid id, string name) : base(id, name) { }

        public User(Guid id, string name, Guid partyId) : base(id, name)
        {
            Party = new PartyRef(partyId, DateTime.Now);
        }

        public void AssignParty(Party party)
        {
            this.Party = new PartyRef(party.Id, DateTime.Now);
        }

    }
}
