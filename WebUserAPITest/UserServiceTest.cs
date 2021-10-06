using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebUserAPI;
using WebUserAPI.Controllers;
using Moq;
using WebUserAPI.Domain;
using WebUserAPI.Model;

namespace WebUserAPITest
{
    public class UserServiceTest : PrincipalServiceTest
    {

        [Fact]
        public void CreatePrincipal_MustCreateAProperUser_WhenGivenCommandTypeIsUser()
        {
            #region Arrange
            var command = new CreatePrincipalCommand
            {
                Name = SOME_NAME,
                Type = USER_TYPE
            };
            mockRepo.Setup(x => x.Create(It.IsAny<Principal>()));
            #endregion

            #region Act
            sut.CreatePrincipal(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Create(It.Is<User>(User => User.Name == command.Name)));
            mockRepo.Verify(x => x.Save());
            mockRepo.VerifyNoOtherCalls();
            #endregion
        }

    }
}
