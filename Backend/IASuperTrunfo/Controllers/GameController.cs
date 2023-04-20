using Domain.Services;
using AutoMapper;
using Data.Repository;
using Domain.DTOs;
using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IUserRepository _userRepository;
        private readonly IThemeRepository _themeRepository;
        private readonly IMapper _mapper;
        private IGameService _gameService;
        public GameController(IGameRepository gameRepository, IMapper mapper, IGameService gameService, IUserRepository userRepository, IThemeRepository themeRepository)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _gameService = gameService;
            _userRepository = userRepository;
            _themeRepository = themeRepository;
        }

        // GET: api/<ThemeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDTO>>> Get()
        {
            var games = _gameRepository.GetAll();
            return _mapper.Map<List<GameDTO>>(games);
        }

        // GET api/<ThemeController>/5
        [HttpGet("{id}")]
        public async Task<GameDTO> GetById(int id)
        {
            var game = _gameRepository.GetById(x => x.Id == id);
            return _mapper.Map<GameDTO>(game);
        }

        // POST api/<ThemeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Game game)
        {
            if (game == null)
                return BadRequest();

            _gameRepository.Add(game);
            await _gameRepository.Commit();

            return Ok();

        }

        // POST api/<ThemeController>/play
        [HttpPost("play")]
        public async Task<ActionResult> Play([FromHeader] int idTheme, [FromBody] IEnumerable<User> users)
        {
            if (users == null)
                return BadRequest();

            if (users.Count() != 2)
                return BadRequest("Quantidade de usuários passada é maior do que o jogo comporta");

            if (users.Where(x => x.isArtificial).Count() != 1)
                return BadRequest("Não foi informado nenhum usuário IA");

            var theme = await _themeRepository.GetById(x => x.Id == idTheme);

            if(theme == null)
                return BadRequest();

            foreach(var user in users)
            {
                _userRepository.Add(user);
                await _userRepository.Commit();
            }

            var game = _gameService.Start(theme, users);

            return Ok();

        }

        // PUT api/<ThemeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Game game)
        {
            if (game == null)
                return BadRequest();

            _gameRepository.Update(game);
            await _gameRepository.Commit();

            return Ok();

        }

        // DELETE api/<ThemeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var game = await _gameRepository.GetById(x => x.Id == id);

            if (game == null)
                return NotFound();

            _gameRepository.Delete(game);
            await _gameRepository.Commit();

            return Ok();
        }
    }
}
