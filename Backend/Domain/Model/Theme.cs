using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Theme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Colors { get; set; }
        public byte[]? ProfileImage { get; set; }
        public byte[]? BackgroundImage { get; set; }
        public IEnumerable<Attribute>? Attributes { get; set; }
        public IEnumerable<Card>? Cards { get; set; }
    }
}
