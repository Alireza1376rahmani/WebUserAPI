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
        private const string SOME_GUID = "5b2bf1b5-5edc-4ba5-92c1-330c126bebb7" ;

        public UserServiceTest()
        {
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
            mockRepo.Setup(x => x.AddEntity(It.IsAny<User>())).Returns<User>(user => user.Id);
            #endregion

            #region Act
            sut.CreateUser(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.AddEntity(It.Is<User>(User => User.Name == command.Name)));
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
                Id = Guid.Parse(SOME_GUID)
            };
            mockRepo.Setup(x => x.UpdateEntity(It.IsAny<Guid>(), It.IsAny<string>()));
            #endregion

            #region Act
            sut.UpdateUser(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.UpdateEntity(It.Is<Guid>(x => x== Guid.Parse(SOME_GUID)),command.Name),Times.Once);
            mockRepo.Verify(x => x.Save());
            #endregion
        }

        [Fact]
        public void GetAll_ShouldReturnAnArrayOfUsers_AndCallGetAllUsersFromRepository() 
        {
            #region Arrange
            mockRepo.Setup(x=>x.GetAllEntities()).Returns(()=> {
                var userList = new List<User>();
                userList.Add(new User(Guid.NewGuid(),SOME_NAME));
                userList.Add(new User(Guid.NewGuid(), SOME_NAME));
                return userList;
            });
            #endregion

            #region Act
            var act = sut.GetAll();
            #endregion

            #region Assert
            #endregion
        }
    }
}
