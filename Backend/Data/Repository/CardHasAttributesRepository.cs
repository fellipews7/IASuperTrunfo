using Data.Context;
using Domain.Model;

namespace Data.Repository
{
    public class CardHasAttributesRepository : Repository<CardHasAttribute>, ICardHasAttributesRepository
    {
        public CardHasAttributesRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
