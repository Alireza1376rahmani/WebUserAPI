using System.Collections.Generic;
using System;

namespace WebUserAPI.Model
{
    public class CreatePrincipalCommand
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Guid> Groups { get; set; } = new List<Guid>();
        public Guid PartyId { get; set; }
    }
}

