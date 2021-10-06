using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Domain;
using WebUserAPI.Model;

namespace WebUserAPI.Controllers
{
    public class UserService 
    {
        private readonly IRepository<User> repository;

        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public void CreateUser(CreatePrincipalCommand command)
        {
            var user = new User(Guid.NewGuid(), command.Name);
            repository.Create(user);
            repository.Save();
        }

        public void UpdateUser(UpdatePrincipalCommand command)
        {
            var user = repository.GetById(command.Id);
            user.UpdateName(command.Name);
            repository.Update(user);
            repository.Save();
        }

        public List<User> GetAllUsers()
        {
            return repository.GetAll();
        }

        public User GetUserById(ReadPrincipalCommand command)
        {
            return repository.GetById(command.Id);
        }

        public void DeleteUser(DeletePrincipalCommand command)
        {
            repository.Delete(command.Id);
            repository.Save();
        }
    }
}
