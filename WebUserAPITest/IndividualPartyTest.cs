using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.builders;

namespace WebUserAPITest
{
    public class IndividualPartyTest : PartyTest<IndividualParty,IndividualPartyBuilder>
    {

        public IndividualPartyTest()
        {
            sut = builder.WithLastName(SOME_NAME).WithNationalCode(SOME_STRING).Build();
        }

        protected override IndividualPartyBuilder GetBuilderInstance()
        {
            return new IndividualPartyBuilder();
        }
        
    }
}
