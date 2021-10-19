using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Model;
using WebUserAPI.Model.mappings;

namespace WebUserAPI.Services
{
    public class PartyService : IPartyService
    {
        private readonly IRepository<Party> repository;
        private readonly IMapper _mapper;

        public PartyService(IRepository<Party> repository)
        {
            this.repository = repository;
        }

        public PartyService(IRepository<Party> repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
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

        public List<PartyDto> GetAllParties()
        {
            return repository.GetAll().Select(x => _mapper.Map<PartyDto>(x)).ToList();
        }

        public PartyDto GetPartyById(ReadPartyCommand command)
        {
            var party = repository.GetById<Party>(command.Id);
            var dto = mapPartyToPartyDto(party);

            return dto;
        }

        private PartyDto mapPartyToPartyDto(Party party)
        {
            return new PartyDto
            {
                Id = party.Id,
                Type = ,
                Name = party.Name,
                LastName = party.LastName,
                NationalNumber = party.NationalId
            }
        }

        public void UpdatePartyName(PatchPartyCommand command)
        {
            var party = repository.GetById<Party>(command.Id);
            party.UpdateName(command.Name);
            repository.Update(party);
            repository.Save();
        }

        public void Update(PutPartyCommand command)
        {
            Party party = repository.GetById<Party>(command.Id);

            if (getpartyType(party) == "business")
                party = new BusinessParty(command.Id, command.Name, command.NationalNumber);
            else
                party = new IndividualParty(command.Id,command.Name, command.LastName, command.NationalNumber);

            repository.Update(party);
            repository.Save();
        }

        private string getpartyType(Party party)
        {
            if (party is BusinessParty) return "business";
            return "individual";
        }
    }
}
