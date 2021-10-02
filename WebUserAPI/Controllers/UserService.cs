using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Domain;
using WebUserAPI.Model;

namespace WebUserAPI.Controllers
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;

        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public void CreateUser(CreateUserCommand command)
        {
            var user = new User(Guid.NewGuid(), command.Name);
            repository.Add(user);
            repository.Save();
        }

        public void UpdateUser(UpdateUserCommand command)
        {
            repository.Update(new User(command.Id, command.Name));
            repository.Save();
        }

        public List<User> GetAllUsers()
        {
            return repository.GetAll();
        }

        public User GetUserById(ReadUserCommand command)
        {
            return repository.GetById(command.Id);
        }

        public void DeleteUser(DeleteUserCommand command)
        {
            repository.Delete(command.Id);
            repository.Save();
        }
    }
}
