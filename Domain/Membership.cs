using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Membership
    {
        public Guid GroupId { get; private set; }
        public DateTime JoinDate { get; private set; }
        public Membership(Guid GroupId, DateTime JoinDate)
        {
            this.GroupId = GroupId;
            this.JoinDate = JoinDate;
        }
    }
    public class PartyRef
    {
        public Guid PartyId { get; private set; }
        public DateTime JoinDate { get; private set; }
        public PartyRef(Guid PartyId, DateTime JoinDate)
        {
            this.PartyId = PartyId;
            this.JoinDate = JoinDate;
        }
    }
}
