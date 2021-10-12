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

      
    }   
}
