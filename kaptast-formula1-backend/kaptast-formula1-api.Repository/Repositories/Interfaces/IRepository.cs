using KaptastFormula1Api.Repository.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaptastFormula1Api.Repository.Repositories.Interfaces
{
    /// <summary>
    /// An interface for CRUD database methods.
    /// </summary>
    /// <typeparam name="T">The type of the entities handled by the repository.</typeparam>
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
