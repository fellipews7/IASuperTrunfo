using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Game
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }
        public Theme? Theme { get; set; }
        public IEnumerable<GameHasUser>? Users { get; set; }
    }
}
