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
    public class UserServiceTest
    {
        private Mock<IRepository<User>> mockRepo;
        private UserService sut;

        private const string SOME_NAME = "some valid name";
        private readonly Guid SOME_GUID = Guid.Parse("5b2bf1b5-5edc-4ba5-92c1-330c126bebb7");
        private readonly User SOME_USER ;

        public UserServiceTest()
        {
            SOME_USER = new User(SOME_GUID, SOME_NAME);
            mockRepo = new Mock<IRepository<User>>();
            sut = new UserService(mockRepo.Object);
        }

        [Fact]
        public void CreateUser_MustCreateAProperUser()
        {
            #region Arrange
            var command = new CreateUserCommand
            {
                Name = "some valid name"
            };
            mockRepo.Setup(x => x.Add(It.IsAny<User>())).Returns<User>(user => user.Id);
            #endregion

            #region Act
            sut.CreateUser(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Add(It.Is<User>(User => User.Name == command.Name)));
            mockRepo.Verify(x => x.Save());
            mockRepo.VerifyNoOtherCalls();
            #endregion
        }

        [Fact]
        public void UpdateUser_MustUpdateAUser_WithProperDataModel()
        {
            #region Arrange
            var command = new UpdateUserCommand
            {
                Name = "some another valid name",
                Id = SOME_GUID
            };
            mockRepo.Setup(x => x.Update(It.IsAny<User>()));
            mockRepo.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(SOME_USER);
            #endregion

            #region Act
            sut.UpdateUser(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Update(SOME_USER), Times.Once);
            mockRepo.Verify(x => x.GetById(SOME_GUID),Times.Once);
            mockRepo.Verify(x => x.Save());
            #endregion
        }

        [Fact]
        public void GetAllUsers_ShouldReturnAnArrayOfUsers_AndCallGetAllUsersFromRepository()
        {
            #region Arrange
            mockRepo.Setup(x => x.GetAll()).Returns(() =>
            {
                var userList = new List<User>();
                userList.Add(new User(Guid.NewGuid(), SOME_NAME));
                userList.Add(new User(Guid.NewGuid(), SOME_NAME));
                return userList;
            });
            #endregion

            #region Act
            var act = sut.GetAllUsers();
            #endregion

            #region Assert
            Assert.IsType<List<User>>(act);
            mockRepo.Verify(x => x.GetAll());
            mockRepo.VerifyNoOtherCalls();
            #endregion
        }

        [Fact]
        public void GetUserById_ShouldReturnCorrectUser_WithExistingId()
        {
            #region Arrange
            var command = new ReadUserCommand
            {
                Id = SOME_GUID
            };
            mockRepo.Setup(x => x.GetById(It.IsAny<Guid>())).Returns<Guid>(x => new User(x, SOME_NAME));
            var expectedId = SOME_GUID;
            #endregion

            #region Act
            var act = sut.GetUserById(command);
            #endregion

            #region Assert
            Assert.Equal(expectedId, act.Id);
            #endregion
        }

        [Fact]
        public void DeleteUser_MustDeleteGivenUserFromResource_ByCallingDeleteFromRepository()
        {
            #region Arrange
            var command = new DeleteUserCommand
            {
                Id = SOME_GUID
            };
            mockRepo.Setup(x => x.Delete(It.IsAny<Guid>()));
            #endregion

            #region Act
            sut.DeleteUser(command);
            #endregion

            #region Assert
            Action verify = () =>
            {
                mockRepo.Verify(x => x.Delete(SOME_GUID));
                mockRepo.Verify(x=>x.Save());
            };
            Assert.Null(Record.Exception(verify));
            #endregion
        }

    }
}
