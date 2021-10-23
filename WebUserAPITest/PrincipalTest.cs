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
using Domain.builders;

namespace WebUserAPITest
{
    public abstract class PrincipalTest<TPrincipal,TBuilder> : EntityTest<TPrincipal,TBuilder>
        where TPrincipal : Principal
        where TBuilder :PrincipalBuilder<TPrincipal,TBuilder>
    {
        protected const string SOME_NAME = "some valid name";
        protected Group someGroup;

        protected override void AssertInvariants()
        {
            base.AssertInvariants();
            Assert.Equal(SOME_NAME, sut.Name);
        }

        public PrincipalTest()
        {
            builder.WithName(SOME_NAME);
            someGroup =(Group) new GroupBuilder()
                .WithId(Guid.Parse(SOME_ID))
                .WithName(SOME_NAME)
                .Build();
        }

        [Fact]
        public void AddGroup_MustAddGivenGroupToListOfGroups()
        {
            #region Arrange
            #endregion

            #region Act
            sut.AddGroup(someGroup);
            #endregion

            #region Assert
            Assert.Contains(sut.Memberships, group => group.GroupId.Equals(someGroup.Id));
            #endregion
        }

        [Fact]
        public void RemoveGroup_MustRemoveGivenGroupFromListOfGroups()
        {
            #region Arrange
            sut.AddGroup(someGroup);
            #endregion

            #region Act
            sut.RemoveGroup(someGroup);
            #endregion

            #region Assert
            Assert.Null(sut.Memberships.Find(group => group.GroupId.Equals(someGroup.Id)));
            #endregion
        }

    }
}


