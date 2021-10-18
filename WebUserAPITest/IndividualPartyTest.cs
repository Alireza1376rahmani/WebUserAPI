﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUserAPITest
{
    public class IndividualPartyTest : PartyTest<IndividualParty>
    {
        protected override IndividualParty GetInstance()
        {
            return new IndividualParty(Guid.Parse(SOME_ID),SOME_NAME,SOME_NAME,SOME_STRING);
        }
    }
}
