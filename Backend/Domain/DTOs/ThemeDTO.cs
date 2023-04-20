using Domain.Model;


namespace Domain.DTOs
{
    public class ThemeDTO
    {
        public string Name { get; set; }
        public string Colors { get; set; }
        public byte[] ProfileImage { get; set; }
        public byte[] BackgroundImage { get; set; }
        public IEnumerable<AttributeDTO> Attributes { get; set; }
        public IEnumerable<CardDTO> Cards { get; set; }
    }
}
