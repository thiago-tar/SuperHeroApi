using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.API.DTOs;
using SuperHero.Dominio.DI;
using SuperHero.Dominio.Models;

namespace SuperHero.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IMapper mapper;

        public HeroController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroDTO>>> Get()
        {
            try
            {
                var heros = await Dependencies.HeroRepository.GetAllAsync();
                return Ok(heros);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HeroDTO>> Get(int id)
        {
            try
            {
                var hero = await Dependencies.HeroRepository.GetByIdAsync(id);

                if (hero == null)
                    return NotFound($"There is no hero with the id {id}");

                return Ok(hero);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<HeroDTO>> Post([FromBody] HeroDTO heroDTO)
        {
            var hero = mapper.Map<Hero>(heroDTO);
            hero = await Dependencies.HeroRepository.Save(hero);
            heroDTO = mapper.Map<HeroDTO>(hero);
                
            return Ok(heroDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entitidade = await Dependencies.HeroRepository.GetByIdAsync(id);
            if (entitidade == null) return NotFound($"There is no Hero with the id {id}");

            await Dependencies.HeroRepository.Delete(entitidade);

            return NoContent();

        }

    }
}
