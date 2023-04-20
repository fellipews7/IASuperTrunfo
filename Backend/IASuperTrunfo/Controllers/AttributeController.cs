using AutoMapper;
using Data.Repository;
using Domain.DTOs;
using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Attribute = Domain.Model.Attribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private IAttributeRepository _attributeRepository;
        private IMapper _mapper;

        public AttributeController(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }

        // GET: api/<ThemeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttributeDTO>>> Get()
        {
            var attributes = _attributeRepository.GetAll();
            return _mapper.Map<List<AttributeDTO>>(attributes);
        }

        // GET api/<ThemeController>/5
        [HttpGet("{id}")]
        public async Task<AttributeDTO> GetById(int id)
        {
            var attribute = _attributeRepository.GetById(x => x.Id == id);
            return _mapper.Map<AttributeDTO>(attribute);
        }

        // POST api/<ThemeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Attribute attribute)
        {
            if (attribute == null)
                return BadRequest();

            _attributeRepository.Add(attribute);
            await _attributeRepository.Commit();

            return Ok();

        }

        // PUT api/<ThemeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Attribute attribute)
        {
            if (attribute == null)
                return BadRequest();

            _attributeRepository.Update(attribute);
            await _attributeRepository.Commit();

            return Ok();

        }

        // DELETE api/<ThemeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var attribute = await _attributeRepository.GetById(x => x.Id == id);

            if (attribute == null)
                return NotFound();

            _attributeRepository.Delete(attribute);
            await _attributeRepository.Commit();

            return Ok();
        }
    }
}
