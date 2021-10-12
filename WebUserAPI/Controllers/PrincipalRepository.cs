﻿using Domain;
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
            Console.WriteLine();
        }

  

        public void Delete(Principal entity)
        {
            list.Remove(entity.Id);
        }

        public List<Principal> GetAll()
        {
            return list.Values.ToList();
        }

        public Principal GetById(Guid id)
        {
            if(list.ContainsKey(id))
                return list[id];
            return null;
        }

        public Principal GetByIdNoTrack(Guid id)
        {
            if (list.ContainsKey(id))
                return list[id];
            return null;
        }

        public void Save() { }

        public void Update(Principal entity)
        {
            list[entity.Id] = entity;
        }

    }
}
