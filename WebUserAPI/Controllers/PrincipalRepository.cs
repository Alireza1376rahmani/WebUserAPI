﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Domain;

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
            Console.WriteLine();
        }

        public void Delete(Guid id)
        {
            list.Remove(id);
        }

        public List<Principal> GetAll()
        {
            List<Principal> copy = new List<Principal>();
            foreach (var item in list)
                copy.Add(item.Value);
            return copy;
        }

        public Principal GetById(Guid id)
        {
            if(list.ContainsKey(id))
                return list[id];
            return null;
        }

        public void Save() { }

        public void Update(Principal entity)
        {
            list.Remove(entity.Id);
            list.Add(entity.Id, entity);
        }

    }
}
