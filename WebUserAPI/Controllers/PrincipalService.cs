using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebUserAPI.Model;

namespace WebUserAPI.Controllers
{
    public class PrincipalService : IPrincipalService
    {
        protected readonly IRepository<Principal> repository;

        public PrincipalService(IRepository<Principal> repository)
        {
            this.repository = repository;
        }

        public Guid CreatePrincipal(CreatePrincipalCommand command)
        {
            Principal principal;
            var guid = Guid.NewGuid();
            if (command.Type == "user")
                principal = new User(guid, command.Name);
            else
                principal = new Group(guid, command.Name);
            repository.Create(principal);
            repository.Save();
            return guid;
        }

        public void UpdatePrincipal(UpdatePrincipalCommand command)
        {
            var principal = repository.GetById<Principal>(command.Id);
            principal.UpdateName(command.Name);
            repository.Update(principal);
            repository.Save();
        }

        public List<Principal> GetAllPrincipals()
        {
            return repository.GetAll();
        }

        public Principal GetPrincipalById(ReadPrincipalCommand command)
        {
            return repository.GetById<Principal>(command.Id);
        }

        public void DeletePrincipal(DeletePrincipalCommand command)
        {
            var principal = repository.GetById<Principal>(command.Id);
            repository.Delete(principal);
            repository.Save();
        }

        public void PrincipalJoinsToGroup(PrincipalJoinsToGroupCommand command)
        {
            var thePrincipal = repository.GetById<Principal>(command.PrincipalId);
            var theGroup = repository.GetById<Group>(command.GroupId);

            thePrincipal.AddGroup(theGroup);

            repository.Update(thePrincipal);
            repository.Save();
        }

        public void PrincipalLeavesGroup(PrincipalLeavesGroupCommand command)
        {
            var thePrincipal = repository.GetById<Principal>(command.PrincipalId);
            var theGroup = repository.GetById<Group>(command.GroupId);

            thePrincipal.RemoveGroup(theGroup);

            repository.Update(thePrincipal);
            repository.Save();
        }

        public List<Group> getAllGroups(Guid id)
        {
            return repository.getGroupsOf(id);
        }
        public Guid CreatePrincipalWithGroups(CreatePrincipalWithGroupsCommand command)
        {
            Principal principal;
            var guid = Guid.NewGuid();
            if (command.Type == "user")
                principal = new User(guid, command.Name, command.groups);
            else
                principal = new Group(guid, command.Name, command.groups);
            repository.Create(principal);
            repository.Save();
            return guid;
        }

        public void UpdatePrincipal(PatchCommand command)
        {
            
        }
    }
}
