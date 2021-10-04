using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserAPI.Domain;

namespace WebUserAPITest
{
    public class GroupTest : PrincipalTest<Group>
    {
        protected override Group GetInstance()
        {
            return new Group(Guid.Parse(SOME_ID),SOME_NAME);
        }
    }
}
