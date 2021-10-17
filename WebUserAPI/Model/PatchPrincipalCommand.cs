using System;

namespace WebUserAPI.Model
{
    public class PatchPrincipalCommand
    {
        public PrincipalPatchType Order { get; set; } = PrincipalPatchType.ChangeName;
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
    }
}

