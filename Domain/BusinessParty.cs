using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BusinessParty : Party
    {
        public string NationalId { get; private set; }

        public BusinessParty(Guid Id, string Name, string NationalId) : base(Id, Name) {
            this.NationalId = NationalId;
        }


    }
}
