using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Domain;

namespace WebUserAPI.Controllers
{
    public class PrincipalRepository<TPrincipal> : IRepository<TPrincipal>
        where TPrincipal : Principal
    {

        private Dictionary<Guid, TPrincipal> list;

        public PrincipalRepository()
        {
            list = new Dictionary<Guid, TPrincipal>();
        }

        public void Create(TPrincipal entity)
        {
            list.Add(entity.Id, entity);
        }

        public void Delete(Guid id)
        {
            list.Remove(id);
        }

        public List<TPrincipal> GetAll()
        {
            List<TPrincipal> copy = new List<TPrincipal>();
            foreach (var item in list)
                copy.Add(item.Value);
            return copy;
        }

        public TPrincipal GetById(Guid id)
        {
            return list[id];
        }

        public void Save() { }

        public void Update(TPrincipal entity)
        {
            list.Remove(entity.Id);
            list.Add(entity.Id, entity);
        }
    }
}
