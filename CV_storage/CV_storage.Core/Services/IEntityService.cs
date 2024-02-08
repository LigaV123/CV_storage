﻿using CV_storage.Core.Models;

namespace CV_storage.Core.Services
{
    public interface IEntityService<T> where T : Entity
    {
        IQueryable<T> Query();
        IQueryable<T> QueryById(int id);
        IEnumerable<T> Get();
        T? GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        bool Exists(int id);
        void DeleteById(int id);
    }
}
