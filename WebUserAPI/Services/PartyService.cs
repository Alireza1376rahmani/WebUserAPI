using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Model;

namespace WebUserAPI.Services
{
    public class PartyService : IPartyService
    {
        private readonly IRepository<Party> repository;

        public PartyService(IRepository<Party> repository)
        {
            this.repository = repository;
        }

        public Guid CreateParty(CreatePartyCommand command)
        {
            Party party;
            Guid guid = Guid.NewGuid();

            if (command.Type == "business")
                party = new BusinessParty(guid, command.Name, command.NationalNumber);
            else
                party = new IndividualParty(guid, command.Name, command.LastName, command.NationalNumber);

            repository.Create(party);
            repository.Save();

            return guid;
        }

        public void DeleteParty(DeletePartyCommand command)
        {
            Party party = repository.GetById<Party>(command.Id);

            repository.Delete(party);
            repository.Save();
        }

        public List<Party> GetAllParties()
        {
            return repository.GetAll();
        }

        public Party GetPartyById(ReadPartyCommand command)
        {
            if (command.Type == "business")
                return repository.GetById<BusinessParty>(command.Id);
            return repository.GetById<IndividualParty>(command.Id);
        }

        public void UpdatePartyName(PatchPartyCommand command)
        {
            var party = repository.GetById<Party>(command.Id);
            party.Name = command.Name;
            repository.Update(party);
            repository.Save();
        }

        public void Update(PutPartyCommand command)
        {
            Party party = repository.GetById<Party>(command.Id);

            repository.Delete(party); 
            repository.Save();

            if (getpartyType(party) == "business")
                party = new BusinessParty(command.Id, command.Name, command.NationalNumber);
            else
                party = new IndividualParty(command.Id,command.Name, command.LastName, command.NationalNumber);

            repository.Create(party);
            repository.Save();
        }

        private string getpartyType(Party party)
        {
            if (party is BusinessParty) return "business";
            return "individual";
        }
    }
}
