using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class CardHasAttribute
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public Card? Card { get; set; }
        public int AttributeId { get; set; }
        public Attribute? Attribute { get; set; }
        public decimal Value { get; set; }
    }
}
