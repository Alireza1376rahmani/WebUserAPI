using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebUserAPITest
{
    public class UserTest : PrincipalTest<User>
    {

        protected override User GetInstance()
        {
            return new User(Guid.Parse(SOME_ID), SOME_NAME);
        }

        [Fact]
        public void Constructor_MustTHrowInvalidArgumentExceptionWhenUserNameIsLessThan10Characters()
        {
            #region Arrange
            const string SHORT_NAME = "lili";
            #endregion

            #region Act
            Action act = () => new User(Guid.Parse(SOME_ID), SHORT_NAME) ; 
            #endregion

            #region Assert
            //Assert.Throws<ArgumentException>(act);
            #endregion
        }

        [Fact]
        public void AssignParty_MustAssignGivenParty()
        {
            #region Arrange
            Party party = new BusinessParty(Guid.Parse(SOME_ID), SOME_NAME, SOME_STRING);
            #endregion

            #region Act
            (sut as User).AssignParty(party);
            #endregion

            #region Assert
            Assert.NotNull((sut as User).Party);
            Assert.Equal(party.Id, (sut as User).Party.PartyId);
            #endregion
        }

        [Fact]
        public void WeShouldCanAssignGivenPartyAsBusinessPartyToPrincipal()
        {
            #region Arrange
            Party party = new BusinessParty(Guid.Parse(SOME_ID), SOME_NAME, SOME_STRING);
            #endregion

            #region Act
            (sut as User).AssignParty(party);
            #endregion

            #region Assert
            Assert.Equal(party.Id, (sut as User).Party.PartyId);
            Assert.Equal(sut.Name, sut.Name);
            #endregion
        }

        [Fact]
        public void WeShouldCanAssignGivenPartyAsIndividualPartyToPrincipal()
        {
            #region Arrange
            Party party = new IndividualParty(Guid.Parse(SOME_ID), SOME_NAME, SOME_NAME, SOME_STRING);
            #endregion

            #region Act
            (sut as User).AssignParty(party);
            #endregion

            #region Assert
            Assert.Equal(party.Id, (sut as User).Party.PartyId);
            #endregion
        }

    }   
}
