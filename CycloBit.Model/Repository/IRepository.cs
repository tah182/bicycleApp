using System.Collections.Generic;
using CycloBit.Model.Entities;

namespace CycloBit.Model.Repository {
    public interface IRepositoryInt<T> where T : BaseEntity<int> {
        IEnumerable <T> GetAll();  
        T Get(int id);  
        void Insert(T entity);  
        void Update(T entity);  
        void Delete(T entity);  
    }

    public interface IRepositoryLong<T> where T : BaseEntity<long> {
        IEnumerable <T> GetAll();  
        T Get(long id);  
        void Insert(T entity);  
        void Update(T entity);  
        void Delete(T entity);  
    }

    public interface IRepositoryString<T> where T : BaseEntity {
        IEnumerable <T> GetAll();  
        T Get(string id);  
        void Insert(T entity);  
        void Update(T entity);  
        void Delete(T entity);  
    }
}