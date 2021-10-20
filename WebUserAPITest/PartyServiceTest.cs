using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebUserAPI;
using Moq;
using Domain;
using WebUserAPI.Services;
using WebUserAPI.Model;
using AutoMapper;
using WebUserAPI.Model.mappings;

namespace WebUserAPITest
{
    public class PartyServiceTest
    {
        protected Mock<IRepository<Party>> mockRepo;
        protected PartyService sut;

        protected const string SOME_NAME = "some valid name";
        protected const string SOME_GUID = "5b2bf1b5-5edc-4ba5-92c1-330c126bebb7";
        protected readonly User SOME_USER;
        protected const string SOME_STRING = "some string";

        public PartyServiceTest()
        {
            SOME_USER = new User(Guid.Parse(SOME_GUID), SOME_NAME);
            mockRepo = new Mock<IRepository<Party>>();
            mockRepo.Setup(x => x.Save());
            mockRepo.Setup(x => x.GetById<Party>(It.IsAny<Guid>())).Returns<Guid>(id => new IndividualParty(id, SOME_NAME, SOME_NAME, SOME_STRING));
            mockRepo.Setup(x => x.GetById<IndividualParty>(It.IsAny<Guid>())).Returns<Guid>(id => new IndividualParty(id, SOME_NAME, SOME_NAME, SOME_STRING));
            mockRepo.Setup(x => x.GetById<BusinessParty>(It.IsAny<Guid>())).Returns<Guid>(id => new BusinessParty(id, SOME_NAME, SOME_STRING));
            
            sut = new PartyService(mockRepo.Object);
        }

        [Fact]
        public void CreateParty_MustCreateABussinessParty_WithProperDataModel()
        {
            #region Arrange
            var command = new CreatePartyCommand
            {
                Type = "business",
                Name = SOME_NAME,
                LastName = SOME_NAME,
                NationalNumber = SOME_STRING
            };
            #endregion

            #region Act
            sut.CreateParty(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Create(It.Is<Party>(p => p is BusinessParty)), Times.Once);
            mockRepo.Verify(x => x.Save());
            #endregion
        }

        [Fact]
        public void CreateParty_MustCreateAIndividualParty_WithProperDataModel()
        {
            #region Arrange
            var command = new CreatePartyCommand
            {
                Type = "individual",
                Name = SOME_NAME,
                LastName = SOME_NAME,
                NationalNumber = SOME_STRING
            };
            #endregion

            #region Act
            sut.CreateParty(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Create(It.Is<Party>(p => p is IndividualParty)), Times.Once);
            mockRepo.Verify(x => x.Save());
            #endregion
        }

        [Fact]
        public void DeleteParty_MustRemovePartyWithGivenId_WithProperDataModel()
        {
            #region Arrange
            var command = new DeletePartyCommand
            {
                Id = Guid.Parse(SOME_GUID)
            };
            #endregion

            #region Act
            sut.DeleteParty(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Delete(It.Is<Party>(p => p.Id == command.Id)), Times.Once);
            mockRepo.Verify(x => x.Save());
            #endregion
        }

        [Fact]
        public void GetAllParties_MustCallGetAllMethodFromRepository()
        {
            #region Arrange
            mockRepo.Setup(x => x.GetAll()).Returns(new List<Party>());
            #endregion

            #region Act
            var act = sut.GetAllParties();
            #endregion

            #region Assert
            mockRepo.Verify(x => x.GetAll(), Times.Once);
            #endregion
        }

        [Fact]
        public void GetPartyById_MustReturnCorrectParty_WithProperDataModel()
        {
            #region Arrange
            var command = new ReadPartyCommand
            {
                Id = Guid.Parse(SOME_GUID),
            };
            #endregion

            #region Act
            var Act = sut.GetPartyById(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.GetById<Party>(It.Is<Guid>(i => i == command.Id)), Times.Once);
            #endregion
        }

        [Fact]
        public void UpdatePartyName_MustUpdatePartyName_WithProperDataModel()
        {
            #region Arrange
            var command = new PatchPartyCommand
            {
                Id = Guid.Parse(SOME_GUID),
                Name = "some another name"
            };
            #endregion

            #region Act
            sut.UpdatePartyName(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Update(It.Is<Party>(p => p.Id == command.Id)), Times.Once);
            mockRepo.Verify();
            #endregion
        }

        [Fact]
        public void Update_MustUpdateEntirePartyData_WithProperDataModel()
        {
            #region Arrange
            var command = new PutPartyCommand
            {
                Id = Guid.Parse(SOME_GUID),
                Name = SOME_NAME,
                LastName = SOME_NAME,
                NationalNumber = SOME_STRING
            };
            #endregion

            #region Act
            sut.Update(command);
            #endregion

            #region Assert
            mockRepo.Verify(x => x.Update(It.IsAny<Party>()), Times.Once);
            mockRepo.Verify(x => x.Save());
            #endregion
        }



    }
}
