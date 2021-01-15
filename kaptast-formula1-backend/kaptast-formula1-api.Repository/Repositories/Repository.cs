using kaptast_formula1_api.Repository.Entities.Interfaces;
using kaptast_formula1_api.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kaptast_formula1_api.Repository.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : IEntity
    {
        protected readonly FormulaDbContext _dbContext;
        public Repository(FormulaDbContext db)
        {
            this._dbContext = db;
        }

        /// <summary>
        /// Add a <see cref="T"/> entity to the database
        /// </summary>
        /// <param name="entity">Entity to be added to the database</param>
        public void Add(T entity)
        {
            this._dbContext.Add(entity);
        }

        /// <summary>
        /// Deletes the <see cref="T"/> entry from the database
        /// </summary>
        /// <param name="entity">Entity to be deleted from the database</param>
        public void Delete(T entity)
        {
            this._dbContext.Remove(entity);
        }

        /// <summary>
        /// Gets a <see cref="T"/> stored in the database by id
        /// </summary>
        /// <param name="Id">Id of the <see cref="T"/> to be queried</param>
        /// <returns>The queried <see cref="T"/> whose id was passed in the parameter</returns>
        public abstract Task<T> Get(Guid Id);

        /// <summary>
        /// Gets all <see cref="T"/> stored in the database
        /// </summary>
        /// <returns>An enumerable list with all the <see cref="T"/></returns>
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
