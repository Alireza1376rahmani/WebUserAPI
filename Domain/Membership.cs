using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Membership
    {
        public Membership() { }

        public Membership(Principal principal, Group group)
        {
            Principal= principal;
            Group= group;
        }

        public Guid GroupId { get; set; }
        public Guid PrincipalId { get; set; }
        public Principal Principal { get; set; }
        public Group Group { get; set; }
    }
}
