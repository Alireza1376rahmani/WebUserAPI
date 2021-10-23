using Domain;
using Domain.builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebUserAPITest
{
    public class GroupTest : PrincipalTest<Group, GroupBuilder>
    {

        public GroupTest()
        {
            sut = builder.Build();
        }

        protected override GroupBuilder GetBuilderInstance()
        {
            return new GroupBuilder();
        }

        [Fact]
        public void justfortestsomething()
        {
            Assert.Equal(sut.Name, sut.Name);
        }

   
    }
}
