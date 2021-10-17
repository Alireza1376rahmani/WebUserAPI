using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebUserAPI;
using Moq;
using WebUserAPI.Controllers;
using Domain;

namespace WebUserAPITest
{
    public abstract class PrincipalTest<TPrincipal> : EntityTest<Principal>
        where TPrincipal : Principal
    {

        protected const string SOME_NAME = "some valid name";
        protected const string SOME_GUID = "3b2bf1b5-5edc-4ba5-92c1-330c126bebb7";

        protected abstract override TPrincipal GetInstance();


        protected override void AssertInvariants()
        {
            base.AssertInvariants();
            Assert.Equal(SOME_NAME, sut.Name);
        }

        [Fact]
        public void AddGroup_MustAddGivenGroupToListOfGroups()
        {
            #region Arrange
            var someGroup = new Group(Guid.NewGuid(), SOME_NAME);
            #endregion

            #region Act
            sut.AddGroup(someGroup);
            #endregion

            #region Assert
            Assert.Contains(sut.Memberships, group => group.GroupId.Equals(someGroup.Id));
            #endregion
        }

    }
}
