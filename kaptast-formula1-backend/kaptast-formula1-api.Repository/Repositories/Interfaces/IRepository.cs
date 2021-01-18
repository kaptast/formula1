using KaptastFormula1Api.Repository.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaptastFormula1Api.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> Get(Guid Id);
        Task<List<T>> Get();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task Save();
    }
}
