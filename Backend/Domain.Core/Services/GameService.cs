using Domain.Services;
using AutoMapper;
using Domain.DTOs;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Data.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using Data.Context;

namespace Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly IGameHasUserRepository _gameHasUserRepository;
        private readonly IUserHasCardsRepository _userHasCardsRepository;
        private readonly ICardRepository _cardRepository;

        public GameService(IMapper mapper, IGameRepository gameRepository, IGameHasUserRepository gameHasUserRepository, ICardRepository cardRepository, IUserHasCardsRepository userHasCardsRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
            _gameHasUserRepository = gameHasUserRepository;
            _cardRepository = cardRepository;
            _userHasCardsRepository = userHasCardsRepository;
        }

        public async Task<ActionResult<GameDTO>> Start(Theme theme, IEnumerable<User> users)
        {
            try
            {

                Game game = new Game()
                {
                    ThemeId = theme.Id,
                    Theme = theme
                };

                using (var db = new DatabaseContext())
                {

                }
                Random random = new Random();


                _gameRepository.Add(game);
                //_gameRepository.SaveChanges();

                var gameUser = new GameHasUser() {
                    IdGame = game.Id,
                    Match = game
                };

                var gameIa = new GameHasUser(){
                    IdGame = game.Id,
                    Match = game
                };

                _gameHasUserRepository.Add(gameUser);
                //await _gameHasUserRepository.Commit();
                _gameHasUserRepository.Add(gameIa);
                //await _gameHasUserRepository.Commit();

                var cards = _cardRepository.GetAll().Where(x => x.MainTheme.Id == game.ThemeId).ToList();

                for (int i = 0; (cards.Count() / 2) >= 1; i++)
                {
                    int cardNumber = random.Next(0, cards.Count() - 1);
                    var cardPlayer = cards.ToList()[cardNumber];
                    UserHasCards cardsPlayer = new UserHasCards()
                    {
                        CardId = cardPlayer.Id,
                        Card = cardPlayer,
                        IdUser = users.ToList()[0].Id,
                        User = users.ToList()[0],
                        CardsSequence = i
                    };

                    cards.Remove(cardPlayer);

                    cardNumber = random.Next(0, cards.Count() - 1);
                    cardPlayer = cards.ToList()[cardNumber];

                    UserHasCards cardsIa = new UserHasCards()
                    {
                        CardId = cardPlayer.Id,
                        Card = cardPlayer,
                        IdUser = users.ToList()[1].Id,
                        User = users.ToList()[1],
                        CardsSequence = i
                    };
                    _userHasCardsRepository.Add(cardsPlayer);
                    _userHasCardsRepository.Add(cardsIa);
                    
                }
                await _userHasCardsRepository.Commit();
                return _mapper.Map<GameDTO>(game);
            }
            catch(Exception ex)
            {
                return new GameDTO();
            }

        }

        public async Task<ActionResult<MoveDTO>> Round(MoveDTO move)
        {
            //var game = _uow.GameHasUserRepository.GetById(x => x.IdGame == move.gameId);
            /*
            //if (game == null)
            //return new Exception("Nenhum jogo encontrado!");

            var cardMove = await _uow.AttributeRepository.GetAll()
                                                         .Include(x => x.Cards)
                                                         .ThenInclude(x => x.Card)
                                                         .ThenInclude(x => x.UserHasCards)
                                                         .ThenInclude(x => x.Game)
                                                         .FirstOrDefaultAsync(c => c.Cards.Card.Game.GameId == move.gameId
                                                                                && c.Cards.Card.IdUser == move.idUser
                                                                          && c.UserHasCards.CardId == move.cardId
                                                                          && c.UserHasCards.Card.Attributes.Attribute); ;

            var cardAgainst = await _uow.GameHasUserRepository.GetAll()
                                                        .Include(x => x.UserHasCards)
                                                        .ThenInclude(x => x.Card)
                                                        .ThenInclude(x => x.Attributes)
                                                        .ThenInclude(x => x.Attribute)
                                                        .Where(c => c.GameId == move.gameId 
                                                                 && c.UserHasCards.IdUser != move.idUser)
                                                        .OrderBy(x => x.UserHasCards.CardsSequence)
                                                        .FirstOrDefaultAsync();

            //if (cardMove == null || cardAgainst == null)
              //  return ("Cartas informadas não encontradas");

            move.isWinner = cardMove.UserHasCards.Card.Attributes.Any(a => a)
            */
            return move;
        }
    }
}
