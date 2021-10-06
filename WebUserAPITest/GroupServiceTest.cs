using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebUserAPI;
using Moq;
using WebUserAPI.Controllers;
using WebUserAPI.Domain;
using WebUserAPI.Model;

namespace WebUserAPITest
{
    public class GroupServiceTest
    {
        GroupService sut;
        Mock<IRepository<Group>> mockRepo;

        private const string SOME_NAME = "some valid name";
        private const string SOME_GUID = "3b2bf1b5-5edc-4ba5-92c1-330c126bebb7";

        public GroupServiceTest()
        {
            mockRepo = new Mock<IRepository<Group>>();
            sut = new GroupService(mockRepo.Object);
        }

        [Fact]
        public void CreateGroup_MustWorkCorrectly_WithCompleteAndCorrectCommand()
        {
            #region Arrange
            var command = new CreateGroupCommand
            {
                Name = SOME_NAME
            };
            mockRepo.Setup(x => x.Create(It.IsAny<Group>()));
            mockRepo.Setup(x => x.Save());
            #endregion

            #region Act
            sut.CreateGroup(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Create(It.Is<Group>(x => x.Name == SOME_NAME)), Times.Once);
            mockRepo.Verify(x => x.Save());
            mockRepo.VerifyNoOtherCalls();
            #endregion
        }

        [Fact]
        public void UpdateGroup_MustWorkCorrectly_WithProperCommand()
        {
            #region Arrange
            var anotherName = "another valid name";
            var command = new UpdateGroupCommand
            {
                Id = Guid.Parse(SOME_GUID),
                Name = anotherName
            };
            mockRepo.Setup(x => x.Update(It.IsAny<Group>()));
            mockRepo.Setup(x => x.GetById(It.IsAny<Guid>())).Returns<Guid>(id=> new Group(id,SOME_NAME));
            #endregion

            #region Act
            sut.UpdateGroup(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Update(It.Is<Group>(x => (x.Name == anotherName && x.Id == Guid.Parse(SOME_GUID)))));
            mockRepo.Verify(x => x.Save());
            #endregion
        }


        [Fact]
        public void GetGroupById_MustWorkCorrectly_WithProperCommand()
        {
            #region Arrange
            #endregion

            #region Act
            sut.
            #endregion

            #region Assert
            #endregion
        }
    }
}
