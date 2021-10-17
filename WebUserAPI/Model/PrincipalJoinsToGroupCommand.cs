using System;

namespace WebUserAPI.Model
{
    public class PrincipalJoinsToGroupCommand
    {
        public Guid PrincipalId { get; set; }
        public Guid GroupId { get; set; }
    }
}

