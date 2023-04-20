using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[]? Image { get; set; }
        public int ThemeId { get; set; }
        public IEnumerable<UserHasCards>? UserHasCards { get; set; }
        public Theme? MainTheme { get; set; }
        public IEnumerable<CardHasAttribute>? Attributes { get; set; }

    }
}
