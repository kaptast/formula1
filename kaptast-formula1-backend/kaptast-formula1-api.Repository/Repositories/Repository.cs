using KaptastFormula1Api.Repository.Entities.Interfaces;
using KaptastFormula1Api.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaptastFormula1Api.Repository.Repositories
{
    /// <summary>
    /// Abstract base class which implements the generic functions of <see cref="IRepository{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the entities handled by the repository.</typeparam>
    public abstract class Repository<T> : IRepository<T> where T : IEntity
    {
        protected readonly FormulaDbContext _dbContext;
        public Repository(FormulaDbContext db)
        {
            this._dbContext = db;
        }

        /// <summary>
        /// Add a <see cref="IEntity"/> entity to the database
        /// </summary>
        /// <param name="entity">Entity to be added to the database</param>
        public void Add(T entity)
        {
            this._dbContext.Add(entity);
        }

        /// <summary>
        /// Deletes the <see cref="IEntity"/> entry from the database
        /// </summary>
        /// <param name="entity">Entity to be deleted from the database</param>
        public void Delete(T entity)
        {
            this._dbContext.Remove(entity);
        }

        public abstract Task<T> Get(Guid Id);
        public abstract Task<List<T>> Get();
        
        /// <summary>
        /// Saves the database
        /// </summary>
        /// <returns>Awaitable task which saves the database</returns>
        public Task Save()
        {
            return this._dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the database with the modified entity
        /// </summary>
        /// <param name="entity">Entity to be modified</param>
        public void Update(T entity)
        {
            this._dbContext.Update(entity);
        }
    }
}
