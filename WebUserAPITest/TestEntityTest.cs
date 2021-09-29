using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUserAPITest
{
    public class TestEntityTest : EntityTest<TestEntity>
    {
        protected override TestEntity GetInstance()
        {
            return new TestEntity(Guid.Parse(SOME_ID));
        }
    }
}
