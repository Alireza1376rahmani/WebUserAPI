using System;
using System.Collections.Generic;
using WebUserAPI.Domain;

namespace WebUserAPI.Controllers
{
    public interface IRepository<TEntity> 
        where TEntity:Entity
    {
        public TSubEntity GetById<TSubEntity>(Guid id) where TSubEntity : TEntity;
        public TEntity GetById(Guid id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll();
        void Delete(Guid id);
        public void Save();
    }
}