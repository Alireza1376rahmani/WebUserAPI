using Domain;
using Domain.builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUserAPITest
{
    public class TestPrincipalTest : PrincipalTest<TestPrincipal, TestPrincipalBuilder>
    {
        public TestPrincipalTest()
        {
            sut = builder.Build();
        }

        protected override TestPrincipalBuilder GetBuilderInstance()
        {
            return new TestPrincipalBuilder();
        }
    }

    public class TestPrincipalBuilder : PrincipalBuilder<TestPrincipal, TestPrincipalBuilder>
    {
        public override TestPrincipal Build()
        {
            return new TestPrincipal(id, name);
        }
    }
}
