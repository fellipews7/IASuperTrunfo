using Data.Context;
using Domain.Model;

namespace Data.Repository
{
    public class GameHasUserRepository : Repository<GameHasUser>, IGameHasUserRepository
    {
        public GameHasUserRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
