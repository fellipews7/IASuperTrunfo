using Domain.Model;

namespace Domain.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public int CardId { get; set; }
        public IEnumerable<Card> Cards { get; set; }
    }
}
