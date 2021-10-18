using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Model;

namespace WebUserAPI.Services
{
    public class PartyService
    {
        private readonly IRepository<Party> repository;

        public PartyService(IRepository<Party> repository)
        {
            this.repository = repository;
        }

        public Guid CreateParty(CreatePartyCommand command)
        {
            throw new NotImplementedException();
        }

        public void DeleteParty(DeletePartyCommand command)
        {
            throw new NotImplementedException();
        }

        public List<Party> GetAllPrincipals()
        {
            throw new NotImplementedException();
        }

        public Party GetPartyById(ReadPartyCommand command)
        {
            throw new NotImplementedException();
        }

        public void UpdateParty(PatchPartyCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
