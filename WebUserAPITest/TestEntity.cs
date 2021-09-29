using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserAPI.Domain;

namespace WebUserAPITest
{
    public class TestEntity : Entity
    {
        public TestEntity(Guid id) : base(id)
        {
        }
    }
}
