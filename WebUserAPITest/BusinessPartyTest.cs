using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.builders;

namespace WebUserAPITest
{
    public class BusinessPartyTest : PartyTest<BusinessParty,BusinessPartyBuilder>
    {

        public BusinessPartyTest()
        {
            sut = builder.WithNationalId(SOME_STRING).Build();
        }

        protected override BusinessPartyBuilder GetBuilderInstance()
        {
            return new BusinessPartyBuilder();
        }

    }
}
