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
    public class ThemeRepository : Repository<Theme>, IThemeRepository
    {
        public ThemeRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<Theme> GetCards()
        {
            return _context.Theme.Include(x => x.Cards)
                                 .ThenInclude(y => y.Attributes)
                                 .AsNoTracking();
        }

        public IQueryable<Theme> GetAttributes()
        {
            return _context.Theme.Include(x => x.Attributes).AsNoTracking();
        }
    }
}
