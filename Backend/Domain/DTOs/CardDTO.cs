using Domain.Model;

namespace Domain.DTOs
{
    public class CardDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<CardHasAttribute> Attributes { get; set; }
    }
}
