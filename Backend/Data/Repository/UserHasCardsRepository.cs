using Data.Context;
using Domain.Model;

namespace Data.Repository
{
    public class UserHasCardsRepository : Repository<UserHasCards>, IUserHasCardsRepository
    {
        public UserHasCardsRepository(DatabaseContext context) : base(context)
        {
        }
    }
}

