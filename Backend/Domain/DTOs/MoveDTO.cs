using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class MoveDTO
    {
        public int idUser;
        public UserDTO? user;
        public int gameId;
        public GameDTO? game;
        public int cardId;
        public CardDTO? card;
        public int attributeId;
        public AttributeDTO? attribute;
        public bool isWinner;
    }
}
