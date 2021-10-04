using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebUserAPI;
using WebUserAPI.Domain;

namespace WebUserAPITest
{
    public abstract class PrincipalTest<TPrincipal> : EntityTest<Principal>
        where TPrincipal: Principal
    {
        protected const string SOME_NAME = "some valid name";

        protected override void AssertInvariants()
        {
            base.AssertInvariants();
            Assert.Equal(SOME_NAME, sut.Name);
        }

        protected abstract override TPrincipal GetInstance();

    }
}
