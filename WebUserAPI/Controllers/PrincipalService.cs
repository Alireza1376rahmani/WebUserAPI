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
            var groups=command.Groups.Select(id => repository.GetById(id));
            foreach (var group in groups)
            {
                principal.AddGroup((Group)group);
            }
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
            var principal = repository.GetById(command.Id);
            repository.Delete(principal);
            repository.Save();
        }

        public void PrincipalJoinsToGroup(PrincipalJoinsToGroupCommand command)
        {
            var thePrincipal = repository.GetById(command.PrincipalId);
            var groupPrincipal = repository.GetById(command.GroupId);
           

            thePrincipal.AddGroup(groupPrincipal as Group);

            repository.Update(thePrincipal);
            repository.Save();
        }

        public void PrincipalLeavesGroup(PrincipalLeavesGroupCommand command)
        {
            var thePrincipal = repository.GetById(command.PrincipalId);
            var groupPrincipal = repository.GetById(command.GroupId);
          

            thePrincipal.RemoveGroup(groupPrincipal as Group);

            repository.Update(thePrincipal);
            repository.Save();
        }
    }
}
