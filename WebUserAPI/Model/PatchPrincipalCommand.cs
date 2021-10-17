using System;

namespace WebUserAPI.Model
{
    public class PatchPrincipalCommand
    {
        public PrincipalPatchType Order { get; set; } = PrincipalPatchType.ChangeName;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid MemberId { get; set; }
        public Guid GroupId { get; set; }
    }
}

