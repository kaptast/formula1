using kaptast_formula1_api.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace kaptast_formula1_api.Repository.Repositories
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
