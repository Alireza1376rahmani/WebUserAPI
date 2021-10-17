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

        public TSubEntity GetById<TSubEntity>(Guid id) where TSubEntity : Principal
        {
            var res = ctx.Principals.FirstOrDefault(p => p.Id == id);
            return res as TSubEntity;
        }

        public TSubEntity GetByIdNoTrack<TSubEntity>(Guid id) where TSubEntity : Principal
        {
            return ctx.Principals.AsNoTracking().FirstOrDefault(p => p.Id == id) as TSubEntity;
        }

            public void Save()
        {
            ctx.SaveChanges();
        }

        public void Update(Principal entity) { }
    }
}
