using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.builders;

namespace WebUserAPITest
{
    public abstract class PartyTest<TParty,TBuilder> : EntityTest<TParty,TBuilder>
        where TParty:Party
        where TBuilder: PartyBuilder<TParty,TBuilder   >
    {
        protected const string SOME_NAME = "some name";
        public PartyTest()
        {
           builder.WithName(SOME_NAME);
        }

    }
}
