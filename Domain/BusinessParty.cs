using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BusinessParty : Party
    {
        public string NationalId { get; }

        public BusinessParty(Guid id, string name, string nationalId) : base(id, name) {
            NationalId = nationalId;
        }


    }
}
