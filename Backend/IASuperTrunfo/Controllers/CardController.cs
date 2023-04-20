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
    public class CardController : ControllerBase
    {
        private ICardRepository _cardRepository;
        private ICardHasAttributesRepository _cardHasAttributesRepository;
        private IMapper _mapper;

        public CardController(ICardRepository cardRepository, ICardHasAttributesRepository cardHasAttributesRepository,IMapper mapper)
        {
            _cardRepository = cardRepository;
            _cardHasAttributesRepository = cardHasAttributesRepository;
            _mapper = mapper;
        }

        // GET: api/<ThemeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDTO>>> Get()
        {
            var cards = _cardRepository.GetAll();
            return _mapper.Map<List<CardDTO>>(cards);
        }

        // GET api/<ThemeController>/5
        [HttpGet("{id}")]
        public async Task<CardDTO> GetById(int id)
        {
            var card = _cardRepository.GetById(x => x.Id == id);
            return _mapper.Map<CardDTO>(card);
        }

        // POST api/<ThemeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Card card)
        {
            if (card == null)
                return BadRequest();

            _cardRepository.Add(card);
            await _cardRepository.Commit();

            return Ok();

        }

        // POST api/<ThemeController>
        [HttpPost("Attribute")]
        public async Task<ActionResult> AddAttribute([FromBody] IEnumerable<CardHasAttribute> cards)
        {
            foreach(var card in cards)
            {
                if (card == null)
                    return BadRequest();

                _cardHasAttributesRepository.Add(card);
                await _cardHasAttributesRepository.Commit();

            }

            return Ok();
        }

        // PUT api/<ThemeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Card card)
        {
            if (card == null)
                return BadRequest();

            _cardRepository.Update(card);
            await _cardRepository.Commit();

            return Ok();

        }

        // DELETE api/<ThemeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var card = await _cardRepository.GetById(x => x.Id == id);

            if (card == null)
                return NotFound();

            _cardRepository.Delete(card);
            await _cardRepository.Commit();

            return Ok();
        }
    }
}
