﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Domain;
using WebUserAPI.Model;

namespace WebUserAPI.Controllers
{
    public class PrincipalService<TPrincipal>
        where TPrincipal:Principal
    {
        protected readonly IRepository<User> repository;

        public PrincipalService(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public void CreateUser(CreateUserCommand command)
        {
            var user = new User(Guid.NewGuid(), command.Name);
            repository.Create(user);
            repository.Save();
        }

        public void UpdateUser(UpdateUserCommand command)
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
