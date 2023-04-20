using Data.Context;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable GetCardsFromUser(User user)
        {
            return _context.User.Include(x => x.UserHasCards).AsNoTracking();
        }
    }
}
