using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Domain;

namespace WebUserAPI.Controllers
{
    public class UserRepository : IRepository<User>
    {

        private List<User> users;

        public UserRepository()
        {
            users = new List<User>();
        }

        public Guid Add(User entity)
        {
            users.Add(entity);
            return entity.Id;
        }

        public void Delete(Guid id)
        {
            
        }

        public List<User> GetAll()
        {
            return new List<User>();
        }

        public User GetById(Guid id)
        {
            return new User(id, "");
        }

        public void Save(){ }

        public void Update(User entity)
        {
        }
    }
}
