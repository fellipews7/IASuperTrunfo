using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public int ThemeId { get; set; }
        public Theme? Theme { get; set; }
        public IEnumerable<CardHasAttribute>? Cards { get; set; }
    }
}
