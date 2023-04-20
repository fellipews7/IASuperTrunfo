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
    public class ThemeController : ControllerBase
    {
        private IThemeRepository _themeRepository;
        private IMapper _mapper;

        public ThemeController(IThemeRepository themeRepository, IMapper mapper)
        {
            _themeRepository = themeRepository;
            _mapper = mapper;
        }

        // GET: api/<ThemeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThemeDTO>>> Get()
        {
            var themes = _themeRepository.GetAll();
            return _mapper.Map<List<ThemeDTO>>(themes);
        }

        // GET api/<ThemeController>/5
        [HttpGet("{id}")]
        public async Task<ThemeDTO> GetById(int id)
        {
            var theme = _themeRepository.GetById(x => x.Id == id);
            return _mapper.Map<ThemeDTO>(theme);
        }

        // POST api/<ThemeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Theme theme)
        {
            if (theme == null)
                return BadRequest();

            _themeRepository.Add(theme);
            await _themeRepository.Commit();

            return Ok();

        }

        // PUT api/<ThemeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Theme theme)
        {
            if (theme == null)
                return BadRequest();

            _themeRepository.Update(theme);
            await _themeRepository.Commit();

            return Ok();

        }

        // DELETE api/<ThemeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var theme = await _themeRepository.GetById(x => x.Id == id);

            if (theme == null)
                return NotFound();

            _themeRepository.Delete(theme);
            await _themeRepository.Commit();

            return Ok();
        }
    }
}
