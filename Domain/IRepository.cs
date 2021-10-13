using System;
using System.Collections.Generic;

namespace Domain
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        public TSubEntity GetById<TSubEntity>(Guid id) where TSubEntity : TEntity;
        public TSubEntity GetByIdNoTrack<TSubEntity>(Guid id) where TSubEntity : TEntity;
        void Create(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll();
        void Delete(TEntity entity);
        public void Save();
    }
}