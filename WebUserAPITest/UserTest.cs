using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserAPI.Domain;
using Xunit;

namespace WebUserAPITest
{
    public class UserTest : EntityTest<User>
    {

        private const string SOME_NAME = "some valid name";

        protected override User GetInstance()
        {
            return new User(Guid.Parse(SOME_ID), SOME_NAME);
        }

        protected override void AssertInvariants()
        {
            base.AssertInvariants();
            Assert.Equal(SOME_NAME, sut.Name);
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
            Assert.Throws<ArgumentException>(act);
            #endregion
        }

      
    }   
}
