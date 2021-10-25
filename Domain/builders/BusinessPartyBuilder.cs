using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.builders
{
    public class BusinessPartyBuilder : PartyBuilder<BusinessParty, BusinessPartyBuilder>
    {

        private string nationalId = "0";

        public BusinessPartyBuilder WithNationalId(string nationalId)
        {
            this.nationalId = nationalId;
            return this;
        }

        public override BusinessParty Build()
        {
            return new BusinessParty(id, name, nationalId);
        }
    }
}
