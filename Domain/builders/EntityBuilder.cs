using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.builders
{
    public abstract class  EntityBuilder<TEntity,TSelf>
        where TEntity:Entity
        where TSelf: EntityBuilder<TEntity,TSelf>
    {
        protected  Guid id;

        public TSelf WithId(Guid id )
        {
            this.id = id;
            return (TSelf)this;
        }

        public abstract TEntity Build();
    }
}
