using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebUserAPI.Controllers
{
    public class PrincipalRepository : IRepository<Principal>
    {

        private Dictionary<Guid, Principal> list;

        public PrincipalRepository()
        {
            list = new Dictionary<Guid, Principal>();
            var guid = Guid.NewGuid();
            list.Add(guid, new User(guid, "default hastam"));
        }

        public void Create(Principal entity)
        {
            list.Add(entity.Id, entity);
        }

        public void Delete(Principal entity)
        {
            list.Remove(entity.Id);
        }

        public List<Principal> GetAll()
        {
            return list.Values.ToList();
        }

        public TSubEntity GetById<TSubEntity>(Guid id)
            where TSubEntity : Principal
        {
            if(list.ContainsKey(id))
                return list[id] as TSubEntity;
            return null;
        }

        public TSubEntity GetByIdNoTrack<TSubEntity>(Guid id)
            where TSubEntity : Principal
        {
            if (list.ContainsKey(id))
                return list[id] as TSubEntity;
            return null;
        }

        public void Save() { }

        public void Update(Principal entity)
        {
            list[entity.Id] = entity;
        }

    }
}
