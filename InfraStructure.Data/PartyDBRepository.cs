using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data
{
    public class PartyDBRepository : IRepository<Party>
    {
        private readonly MyContext ctx;

        public PartyDBRepository(MyContext context)
        {
            this.ctx = context;
        }

        public void Create(Party entity)
        {
            ctx.Parties.Add(entity);
        }

        public void Delete(Party entity)
        {
            ctx.Parties.Remove(entity);
        }

        public List<Party> GetAll()
        {
            return ctx.Parties.AsNoTracking().ToList();
        }

        public TSubEntity GetById<TSubEntity>(Guid id) where TSubEntity : Party
        {
            return ctx.Parties.FirstOrDefault(p => p.Id == id) as TSubEntity;
        }

        public TSubEntity GetByIdNoTrack<TSubEntity>(Guid id) where TSubEntity : Party
        {
            return ctx.Parties.AsNoTracking().FirstOrDefault(p => p.Id == id) as TSubEntity;
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public void Update(Party entity)
        {
            ctx.Parties.Update(entity);
        }
    }
}
