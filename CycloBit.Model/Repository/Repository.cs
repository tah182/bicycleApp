using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CycloBit.Model.Entities;

namespace CycloBit.Model.Repository {
    public class RepositoryInt<T> : IRepositoryInt<T> where T : BaseEntity<int> {
        private readonly CycloBitContext db;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public RepositoryInt(CycloBitContext db) {
            this.db = db;
            entities = db.Set<T>();
        }
        public IEnumerable<T> GetAll() {
            return entities.AsEnumerable();
        }
        public T Get(int id) {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");
            
            entities.Add(entity);
            db.SaveChanges();
        }
        public void Update(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");
            
            db.SaveChanges();
        }
        public void Delete(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");
                
            entities.Remove(entity);
            db.SaveChanges();
        }
    }

    public class RepositoryLong<T> : IRepositoryLong<T> where T : BaseEntity<long> {
        private readonly CycloBitContext db;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public RepositoryLong(CycloBitContext db) {
            this.db = db;
            entities = db.Set<T>();
        }
        public IEnumerable<T> GetAll() {
            return entities.AsEnumerable();
        }
        public T Get(long id) {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");
            
            entities.Add(entity);
            db.SaveChanges();
        }
        public void Update(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");
            
            db.SaveChanges();
        }
        public void Delete(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");
                
            entities.Remove(entity);
            db.SaveChanges();
        }
    }

    public class RepositoryString<T> : IRepositoryString<T> where T : BaseEntity {
        private readonly CycloBitContext db;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public RepositoryString(CycloBitContext db) {
            this.db = db;
            entities = db.Set<T>();
        }
        public IEnumerable<T> GetAll() {
            return entities.AsEnumerable();
        }
        public T Get(string id) {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");
            
            entities.Add(entity);
            db.SaveChanges();
        }
        public void Update(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");
            
            db.SaveChanges();
        }
        public void Delete(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");
                
            entities.Remove(entity);
            db.SaveChanges();
        }
    }
}  