using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }


        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
