using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; }

        public Entity(Guid id)
        {
            this.Id = id;
        }
    }
}
