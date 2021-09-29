using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI.Domain
{
    public class User : Entity
    {
        public User(Guid id, string name) : base(id)
        {
            Guard.Ensures(()=> name.Length > 9,nameof(name));
            this.Name = name;
            
        }

        public string Name { get; }
        public bool IsActive { get; set;}
    }
}
