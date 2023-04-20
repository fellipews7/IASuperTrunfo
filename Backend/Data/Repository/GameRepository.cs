using Data.Context;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<Game> GetUsers(int id)
        {
            return _context.Game.Where(g => g.Id == id)
                                .Include(x => x.Users)
                                .ThenInclude(y => y.UserHasCards)
                                .ThenInclude(y => y.Card)
                                .ThenInclude(z => z.Attributes)
                                .ThenInclude(z => z.Attribute)
                                .Include(x => x.Users)
                                .ThenInclude(y => y.UserHasCards)
                                .ThenInclude(y => y.User)
                                .AsNoTracking();
        }
    }
}
