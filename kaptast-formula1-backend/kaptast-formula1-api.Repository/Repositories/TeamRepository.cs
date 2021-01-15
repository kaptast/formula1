using kaptast_formula1_api.Repository.Entities;
using kaptast_formula1_api.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaptast_formula1_api.Repository.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(FormulaDbContext db)
            : base(db)
        {
        }

        public override Task<Team> Get(Guid Id)
        {
            return this._dbContext.Teams.Where(t => t.Id.Equals(Id)).SingleOrDefaultAsync();
        }

        public override Task<List<Team>> Get()
        {
            return this._dbContext.Teams.ToListAsync();
        }
    }
}
