using Domain;
using System;
using System.Collections.Generic;
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
        List<Group> getAllGroups(Guid id);
        Guid CreatePrincipalWithGroups(CreatePrincipalWithGroupsCommand command);
        void UpdatePrincipal(PatchCommand command);
    }
}