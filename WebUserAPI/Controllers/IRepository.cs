using System;
using System.Collections.Generic;
using WebUserAPI.Domain;

namespace WebUserAPI.Controllers
{
    public interface IRepository<TEntity> 
        where TEntity:Entity
    {
        public TEntity GetById(Guid id);
        public void Save();
        Guid Add(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll();

    }
}