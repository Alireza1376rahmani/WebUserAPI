using Domain;
using Domain.builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUserAPITest
{
    class TestPartyTest : PartyTest<TestParty, TestPartyBuilder>
    {

        public TestPartyTest()
        {
            sut = builder.Build();
        }

        protected override TestPartyBuilder GetBuilderInstance()
        {
            return new TestPartyBuilder();
        }
    }

    class TestPartyBuilder : PartyBuilder<TestParty, TestPartyBuilder>
    {
        public override TestParty Build()
        {
            return new TestParty(id, name);
        }
    }

}
