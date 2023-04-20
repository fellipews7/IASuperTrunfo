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
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<Card> GetCardsAttributes()
        {
            return  _context.Card.Include(x => x.Attributes)
                                 .ThenInclude(y => y.Attribute)
                                 .AsNoTracking();
        }

    }
}
