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
        Guid AddEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        List<TEntity> GetAllEntities();
    }
}