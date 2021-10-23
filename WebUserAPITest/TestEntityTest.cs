using Domain.builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserAPITest;

namespace WebUserAPITest
{
    public class TestEntityTest : EntityTest<TestEntity, TestEntityBuilder>
    {

        public TestEntityTest()
        {
            sut = builder.Build();
        }

        protected override TestEntityBuilder GetBuilderInstance()
        {
            return new TestEntityBuilder();
        }
    }
}


public class TestEntityBuilder : EntityBuilder<TestEntity, TestEntityBuilder>
{
    public override TestEntity Build()
    {
        return new TestEntity(id);
    }
}