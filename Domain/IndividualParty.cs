using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class IndividualParty : Party
    {
        public string LastName { get; set; }
        public string NationalCode { get; set; }

        public IndividualParty(Guid id, string name, string lastName, string nationalCode) : base(id, name)
        {
            LastName = lastName;
            NationalCode = nationalCode;
        }


    }
}
