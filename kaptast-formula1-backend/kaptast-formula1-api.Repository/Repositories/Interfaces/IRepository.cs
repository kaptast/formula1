using kaptast_formula1_api.Repository.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace kaptast_formula1_api.Repository.Repositories.Interfaces
{
    interface IRepository<T> where T : IEntity
    {
        T Get(Guid Id);
        IEnumerable<T> Get();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
