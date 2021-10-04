using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUserAPITest
{
    public class TestPrincipalTest : PrincipalTest<TestPrincipal>
    {
        protected override TestPrincipal GetInstance()
        {
            return new TestPrincipal(Guid.Parse(SOME_ID), SOME_NAME);
        }
    }
}
