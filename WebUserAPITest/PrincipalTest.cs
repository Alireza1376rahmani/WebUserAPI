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
        protected Group someGroup;

        protected abstract override TPrincipal GetInstance();

        protected override void AssertInvariants()
        {
            base.AssertInvariants();
            Assert.Equal(SOME_NAME, sut.Name);
        }

        public PrincipalTest()
        {
            someGroup = new Group(Guid.Parse(SOME_ID), SOME_NAME);
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

        [Fact]
        public void WeShouldCanAssignGivenPartyAsBusinessPartyToPrincipal()
        {
            #region Arrange
            Party party = new BusinessParty(Guid.Parse(SOME_ID),SOME_NAME,SOME_STRING);
            #endregion

            #region Act
            sut.Party = party;
            #endregion

            #region Assert
            Assert.Equal(party.Id, sut.Party.Id);
            #endregion
        }

        [Fact]
        public void WeShouldCanAssignGivenPartyAsIndividualPartyToPrincipal()
        {
            #region Arrange
            Party party = new IndividualParty(Guid.Parse(SOME_ID),SOME_NAME, SOME_NAME , SOME_STRING);
            #endregion

            #region Act
            sut.Party = party;
            #endregion

            #region Assert
            Assert.Equal(party.Id, sut.Party.Id);
            #endregion
        }

    }
}


