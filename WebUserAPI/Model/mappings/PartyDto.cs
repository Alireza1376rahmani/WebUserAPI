using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI.Model.mappings
{
    public class PartyDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalNumber { get; set; }
    }
}
