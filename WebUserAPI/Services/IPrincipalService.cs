using System;
using System.Collections.Generic;
using WebUserAPI.Model;

namespace WebUserAPI.Services
{
    public interface IPrincipalService
    {
        Guid CreatePrincipal(CreatePrincipalCommand command);
        void DeletePrincipal(DeletePrincipalCommand command);
        List<Principal> GetAllPrincipals();
        Principal GetPrincipalById(ReadPrincipalCommand command);
        void PrincipalJoinsToGroup(PatchPrincipalCommand command);
        void PrincipalLeavesGroup(PatchPrincipalCommand command);
        void UpdatePrincipal(PatchPrincipalCommand command);
    }
}