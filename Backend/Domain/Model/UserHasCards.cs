namespace Domain.Model
{
    public class UserHasCards
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public Card? Card { get; set; }
        public int IdUser { get; set; }
        public User? User { get; set; }
        public int CardsSequence { get; set; }
    }
}
