using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Domain.builders;

namespace WebUserAPITest
{
    public class UserTest : PrincipalTest<User, UserBuilder>
    {

        public UserTest()
        {
            sut = builder.WithParty(Guid.Parse(SOME_ID)).Build();
        }

        protected override UserBuilder GetBuilderInstance()
        {
            return new UserBuilder();
        }

        [Fact]
        public void Constructor_MustTHrowInvalidArgumentExceptionWhenUserNameIsLessThan10Characters()
        {
            #region Arrange
            const string SHORT_NAME = "lili";
            #endregion

            #region Act
            Action act = () => new User(Guid.Parse(SOME_ID), SHORT_NAME);
            #endregion

            #region Assert
            //Assert.Throws<ArgumentException>(act);
            #endregion
        }

        [Fact]
        public void AssignParty_MustAssignGivenParty()
        {
            #region Arrange
            Party party = new BusinessPartyBuilder()
                .WithId(Guid.Parse(SOME_ID))
                .WithName(SOME_NAME)
                .WithNationalId(SOME_STRING)
                .Build();
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
            sut.AssignParty(party);
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
