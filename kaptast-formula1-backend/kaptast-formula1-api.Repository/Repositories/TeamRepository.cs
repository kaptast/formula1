using KaptastFormula1Api.Repository.Entities;
using KaptastFormula1Api.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaptastFormula1Api.Repository.Repositories
{
    /// <summary>
    /// Implements the <see cref="Team"/> specific absract functions of <see cref="Repository{T}"/>.
    /// </summary>
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(FormulaDbContext db)
            : base(db)
        {
        }

        /// <summary>
        /// Gets a <see cref="Team"/> stored in the database by id
        /// </summary>
        /// <param name="Id">Id of the <see cref="Team"/> to be queried</param>
        /// <returns>The queried <see cref="Team"/> whose id was passed in the parameter</returns>
        public override Task<Team> Get(Guid Id)
        {
            return this._dbContext.Teams.Where(t => t.Id.Equals(Id)).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets all <see cref="Team"/> stored in the database
        /// </summary>
        /// <returns>An enumerable list with all the <see cref="Team"/></returns>
        public override Task<List<Team>> Get()
        {
            return this._dbContext.Teams.ToListAsync();
        }
    }
}
