using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI.Model
{
    public class PrincipalJoinsGroupCommand
    {
        public Guid PrincipalId { get; set; }
        public Guid GroupId { get; set; }
    }

    public class PrincipalLeavesGroupCommand: PrincipalJoinsGroupCommand { }
}
