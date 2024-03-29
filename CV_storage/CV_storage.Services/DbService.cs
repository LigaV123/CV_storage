﻿using CV_storage.Core.Models;
using CV_storage.Core.Services;
using CV_storage.Data;
using Microsoft.EntityFrameworkCore;

namespace CV_storage.Services
{
    public class DbService : IDbService
    {
        protected readonly CvDbContext _context;

        public DbService(CvDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>().AsQueryable();
        }

        public IQueryable<T> QueryById<T>(int id) where T : Entity
        {
            return _context.Set<T>().Where(e => e.Id == id);
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public void Create<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool Exists<T>(int id) where T : Entity
        {
            return _context.Set<T>().Any(e => e.Id == id);
        }

        public void DeleteById<T>(int id) where T : Entity
        {
            _context.Remove(_context.Set<T>().SingleOrDefault(e => e.Id == id));
            _context.SaveChanges();
        }
    }
}
