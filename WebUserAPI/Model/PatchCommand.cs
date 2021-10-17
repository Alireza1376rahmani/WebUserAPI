using System.Collections.Generic;
using Domain;
using System;

namespace WebUserAPI.Model
{
    public class PatchCommand
    {
        public PrincipalPatchType Type { get; set; }
        public List<Guid> Groups { get; set; }
    }
}

