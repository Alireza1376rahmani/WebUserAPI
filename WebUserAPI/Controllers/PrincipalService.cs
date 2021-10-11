using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Domain;
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
            var principal = repository.GetById(command.Id);
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
            return repository.GetById(command.Id);
        }

        public void DeletePrincipal(DeletePrincipalCommand command)
        {
            repository.Delete(command.Id);
            repository.Save();
        }

        public void PrincipalJoinsToGroup(PrincipalJoinsToGroupCommand command)
        {
            var thePrincipal = repository.GetById(command.PrincipalId);
            var groupPrincipal = repository.GetById(command.GroupId);
            var theGroup = new Group(groupPrincipal.Id, groupPrincipal.Name);

            thePrincipal.AddGroup(theGroup);

            repository.Update(thePrincipal);
        }

        public void PrincipalLeavesGroup(PrincipalLeavesGroupCommand command)
        {
            var thePrincipal = repository.GetById(command.PrincipalId);
            var groupPrincipal = repository.GetById(command.GroupId);
            var theGroup = new Group(groupPrincipal.Id, groupPrincipal.Name);

            thePrincipal.RemoveGroup(theGroup);

            repository.Update(thePrincipal);
        }
    }
}
