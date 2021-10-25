using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.builders
{
    public class IndividualPartyBuilder : PartyBuilder<IndividualParty, IndividualPartyBuilder>
    {
        protected string lastName = "";
        protected string nationalCode = "0";

        public IndividualPartyBuilder WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public IndividualPartyBuilder WithNationalCode(string nationalCode)
        {
            this.nationalCode = nationalCode;
            return this;
        }

        public override IndividualParty Build()
        {
            return new IndividualParty(id, name, lastName, nationalCode);
        }
    }
}
