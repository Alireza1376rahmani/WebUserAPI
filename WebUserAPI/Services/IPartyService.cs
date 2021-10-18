using Domain;
using System;
using System.Collections.Generic;
using WebUserAPI.Model;

namespace WebUserAPI.Services
{
    public interface IPartyService
    {
        Guid CreateParty(CreatePartyCommand command);
        void DeleteParty(DeletePartyCommand command);
        List<Party> GetAllParties();
        Party GetPartyById(ReadPartyCommand command);
        void UpdatePartyName(PatchPartyCommand command);
        public void Update(PutPartyCommand command);
    }
}