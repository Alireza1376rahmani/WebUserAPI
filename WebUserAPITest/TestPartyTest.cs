using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUserAPITest
{
    class TestPartyTest : PartyTest<TestParty>
    {
        protected override TestParty GetInstance()
        {
            return new TestParty(Guid.Parse(SOME_ID),SOME_NAME);
        }
    }
}
