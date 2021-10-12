using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebUserAPI;
using Moq;
using WebUserAPI.Controllers;
using WebUserAPI.Model;
using Domain;

namespace WebUserAPITest
{
    public class GroupServiceTest : PrincipalServiceTest
    {
        [Fact]
        public void CreatePrincipal_MustWorkWithProperCommand_WhenGivenCommandTypeIsGroup()
        {
            #region Arrange
            var command = new CreatePrincipalCommand
            {
                Name = SOME_NAME,
                Type = GROUP_TYPE
            };
            mockRepo.Setup(x => x.Create(It.IsAny<Principal>()));
            #endregion

            #region Act
            sut.CreatePrincipal(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Create(It.Is<Group>(User => User.Name == command.Name)));
            mockRepo.Verify(x => x.Save());
            mockRepo.VerifyNoOtherCalls();
            #endregion
        }
    }
}
