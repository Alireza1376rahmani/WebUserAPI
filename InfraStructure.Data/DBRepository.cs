using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data
{
    public class DBRepository : IRepository<Principal>
    {
        private readonly MyContext ctx;

        public DBRepository(MyContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Principal entity)
        {
            ctx.Users.Add(entity);
        }

        public void Delete(Principal entity)
        {
            ctx.Users.Remove(entity);
        }

        public List<Principal> GetAll()
        {
            return ctx.Users.AsNoTracking().ToList();
        }

        public Principal GetById(Guid id)
        {
            return ctx.Users.FirstOrDefault(p => p.Id == id);
        }

        public Principal GetByIdNoTrack(Guid id)
        {
            return ctx.Users.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public void Update(Principal entity)
        {
            
        }
    }
}
