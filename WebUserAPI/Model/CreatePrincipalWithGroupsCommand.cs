using System.Collections.Generic;
using System;

namespace WebUserAPI.Model
{
    public class CreatePrincipalWithGroupsCommand : CreatePrincipalCommand
    {
        public List<Guid> groups { get; set; }
    }
}

