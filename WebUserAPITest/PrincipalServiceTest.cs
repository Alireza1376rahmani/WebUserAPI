using Domain;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace WebUserAPITest
{
    public class PrincipalServiceTest
    {
        protected Mock<IRepository<Principal>> mockRepo;
        protected WebUserAPI.Services.PrincipalService sut;

        protected const string SOME_NAME = "some valid name";
        protected const string SOME_GUID = "5b2bf1b5-5edc-4ba5-92c1-330c126bebb7";
        protected readonly User SOME_USER;
        protected const string USER_TYPE = "user";
        protected const string GROUP_TYPE = "group";

        public PrincipalServiceTest()
        {
            SOME_USER = new User(Guid.Parse(SOME_GUID), SOME_NAME);
            mockRepo = new Mock<IRepository<Principal>>();
            mockRepo.Setup(x => x.Save());
            mockRepo.Setup(x => x.GetById<Principal>(It.IsAny<Guid>())).Returns<Guid>(id => new Group(id, SOME_NAME));
            mockRepo.Setup(x => x.GetById<User>(It.IsAny<Guid>())).Returns<Guid>(id => new User(id, SOME_NAME));
            sut = new WebUserAPI.Services.PrincipalService(mockRepo.Object);
        }

        [Fact]
        public void UpdatePrincipal_MustUpdateAUser_WithProperDataModel()
        {
            #region Arrange
            var anotherName = "some another valid name";
            var command = new WebUserAPI.Model.PatchPrincipalCommand
            {
                Name = anotherName,
                Id = Guid.Parse(SOME_GUID)
            };
            mockRepo.Setup(x => x.Update(It.IsAny<User>()));
            #endregion

            #region Act
            sut.UpdatePrincipal(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Update(It.Is<Principal>(p=>p.Id == command.Id)), Times.Once);
            mockRepo.Verify(x => x.GetById<Principal>(Guid.Parse(SOME_GUID)), Times.Once);
            mockRepo.Verify(x => x.Save());
            #endregion
        }

        [Fact]
        public void GetAllPrincipals_ShouldReturnAnArrayOfUsers_AndCallGetAllUsersFromRepository()
        {
            #region Arrange
            mockRepo.Setup(x => x.GetAll()).Returns(() =>
            {
                var principalList = new List<Principal>();
                principalList.Add(new User(Guid.NewGuid(), SOME_NAME));
                principalList.Add(new User(Guid.NewGuid(), SOME_NAME));
                return principalList;
            });
            #endregion

            #region Act
            var act = sut.GetAllPrincipals();
            #endregion

            #region Assert
            Assert.IsType<List<WebUserAPI.Model.Principal>>(act);
            mockRepo.Verify(x => x.GetAll());
            mockRepo.VerifyNoOtherCalls();
            #endregion
        }

        [Fact]
        public void GetPrincipalById_ShouldReturnCorrectUser_WithExistingId()
        {
            #region Arrange
            var command = new WebUserAPI.Model.ReadPrincipalCommand
            {
                Id = Guid.Parse(SOME_GUID)
            };
            var expectedId = Guid.Parse(SOME_GUID);
            #endregion

            #region Act
            var act = sut.GetPrincipalById(command);
            #endregion

            #region Assert
            Assert.Equal(expectedId, act.Id);
            #endregion
        }

        [Fact]
        public void DeletePrincipal_MustDeleteGivenUserFromResource_ByCallingDeleteFromRepository()
        {
            #region Arrange
            var command = new WebUserAPI.Model.DeletePrincipalCommand
            {
                Id = Guid.Parse(SOME_GUID)
            };
            mockRepo.Setup(x => x.Delete(It.IsAny<Principal>()));
            #endregion

            #region Act
            sut.DeletePrincipal(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Delete(It.Is<Principal>(principal => principal.Id == command.Id)));
            mockRepo.Verify(x => x.Save());
            #endregion
        }

        [Fact]
        public void PrincipalJoinsToGroup_ShouldAddTheGivenGroupToListOfGroupsForGivenPrincipal()
        {
            #region Arrange
            Guid givenGroupId = Guid.NewGuid();
            var command = new WebUserAPI.Model.PatchPrincipalCommand
            {
                Id = Guid.Parse(SOME_GUID),
                GroupId = givenGroupId
            };
            mockRepo.Setup(x => x.Update(It.IsAny<Principal>()));
            #endregion

            #region Act
            sut.PrincipalJoinsToGroup(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Update(It.Is<Principal>(principal =>
            (principal.Memberships.Find(e => e.GroupId == givenGroupId) != null) && (principal.Id == Guid.Parse(SOME_GUID))
            )));
            #endregion
        }

        [Fact]
        public void PrincipalLeavesGroup_ShouldRemoveTheProperGivenGroupFromListsOfGroupsOfGivenPrincipal()
        {
            #region Arrange
            var givenGroupId = Guid.NewGuid();
            var command = new WebUserAPI.Model.PatchPrincipalCommand
            {
                Id = Guid.Parse(SOME_GUID),
                GroupId = givenGroupId
            };
            #endregion

            #region Act
            sut.PrincipalLeavesGroup(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Update(It.Is<Principal>(x => (x.Id == Guid.Parse(SOME_GUID)) && (x.Memberships.Find(x => x.GroupId == givenGroupId) == null))));
            #endregion
        }

    }
}

