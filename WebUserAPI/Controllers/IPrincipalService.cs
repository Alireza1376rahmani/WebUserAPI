using System;
using System.Collections.Generic;
using WebUserAPI.Domain;
using WebUserAPI.Model;

namespace WebUserAPI.Controllers
{
    public interface IPrincipalService
    {
        Guid CreatePrincipal(CreatePrincipalCommand command);
        void DeletePrincipal(DeletePrincipalCommand command);
        List<Principal> GetAllPrincipals();
        Principal GetPrincipalById(ReadPrincipalCommand command);
        void PrincipalJoinsToGroup(PrincipalJoinsToGroupCommand command);
        void PrincipalLeavesGroup(PrincipalLeavesGroupCommand command);
        void UpdatePrincipal(UpdatePrincipalCommand command);
    }
}