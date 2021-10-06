using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Domain;
using WebUserAPI.Model;

namespace WebUserAPI.Controllers
{
    public class PrincipalService 
    {
        protected readonly IRepository<Principal> repository;

        public PrincipalService(IRepository<Principal> repository)
        {
            this.repository = repository;
        }

        public void CreatePrincipal(CreatePrincipalCommand command)
        {
            Principal principal;
            if (command.Type == "user")
                principal = new User(Guid.NewGuid(), command.Name);
            else
                principal = new Group(Guid.NewGuid(), command.Name);
            repository.Create(principal);
            repository.Save();
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

    }
}
