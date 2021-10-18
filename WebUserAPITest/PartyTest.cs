using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace WebUserAPITest
{
    public abstract class PartyTest<TParty> : EntityTest<Party>
        where TParty:Party
    {
        protected const string SOME_NAME = "some name";


        protected abstract override TParty GetInstance();
    }
}
