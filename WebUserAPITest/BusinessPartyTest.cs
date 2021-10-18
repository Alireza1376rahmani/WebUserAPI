using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUserAPITest
{
    public class BusinessPartyTest : PartyTest<BusinessParty>
    {
        protected override BusinessParty GetInstance()
        {
            return new BusinessParty(Guid.Parse(SOME_ID), SOME_NAME, SOME_STRING);
        }
    }
}
