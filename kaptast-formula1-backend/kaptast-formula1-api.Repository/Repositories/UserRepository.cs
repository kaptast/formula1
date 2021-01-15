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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(FormulaDbContext db)
            : base(db)
        {
        }
        public override Task<User> Get(Guid Id)
        {
            return this._dbContext.Users.Where(t => t.Id.Equals(Id)).SingleOrDefaultAsync();
        }

        public override Task<List<User>> Get()
        {
            return this._dbContext.Users.ToListAsync();
        }
    }
}
