using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class GameHasUser
    {
        public int Id { get; set; }
        public int IdGame { get; set; }
        public Game? Match { get; set; }
        public int? UserHasCardsId { get; set; }
        public UserHasCards? UserHasCards { get; set; }
    }
}
