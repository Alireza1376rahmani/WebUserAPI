using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI.Model
{
    public class PutPartyCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalNumber { get; set; }
    }
}
