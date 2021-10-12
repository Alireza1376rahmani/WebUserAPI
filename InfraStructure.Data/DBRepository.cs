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
            ctx.Principals.Add(entity);
        }

        public void Delete(Principal entity)
        {
            ctx.Principals.Remove(entity);
        }

        public List<Principal> GetAll()
        {
            return ctx.Principals.AsNoTracking().ToList();
        }

        public Principal GetById(Guid id)
        {
            try
            {
                return ctx.Principals.FirstOrDefault(p => p.Id == id);
            }
            catch(Exception e) {
                var e2 = e;
                return null;
                    }
        }

        public Principal GetByIdNoTrack(Guid id)
        {
            return ctx.Principals.AsNoTracking().FirstOrDefault(p => p.Id == id);
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
