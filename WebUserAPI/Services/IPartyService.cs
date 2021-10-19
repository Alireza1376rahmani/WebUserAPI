using Domain;
using System;
using System.Collections.Generic;
using WebUserAPI.Model;
using WebUserAPI.Model.mappings;

namespace WebUserAPI.Services
{
    public interface IPartyService
    {
        Guid CreateParty(CreatePartyCommand command);
        void DeleteParty(DeletePartyCommand command);
        List<PartyDto> GetAllParties();
        PartyDto GetPartyById(ReadPartyCommand command);
        void UpdatePartyName(PatchPartyCommand command);
        public void Update(PutPartyCommand command);
    }
}