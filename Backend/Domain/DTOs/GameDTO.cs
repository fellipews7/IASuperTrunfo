using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GameDTO
    {
        public Theme Theme { get; set; }
        public IEnumerable<GameHasUser> Users { get; set; }
        public IEnumerable<UserHasCards> UserHasCards { get; set; }
    }
}
