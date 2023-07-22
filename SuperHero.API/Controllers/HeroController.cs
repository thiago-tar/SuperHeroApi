using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.API.DTOs;
using SuperHero.Dominio.DI;

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

    }
}
