using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.builders
{
    public abstract class PartyBuilder<TParty, TSelf>: EntityBuilder<TParty, TSelf>
        where TParty:Party
        where TSelf: PartyBuilder<TParty, TSelf>
    {
        protected string name = "";

        public TSelf WithName(string name)
        {
            this.name = name;
            return this as TSelf;
        }

    }
}
