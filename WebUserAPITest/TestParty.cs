using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace WebUserAPITest
{
    class TestParty : Party
    {
        public TestParty(Guid id , string name) : base(id, name) { }
    }
}
