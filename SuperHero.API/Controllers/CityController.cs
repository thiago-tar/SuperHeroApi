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
    public class CityController : ControllerBase
    {
        private readonly IMapper mapper;

        public CityController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> Get()
        {
            try
            {
                var citys = await Dependencies.CityRepository.GetAllAsync();

                return Ok(mapper.Map<IEnumerable<CityDTO>>(citys));
            }
            catch (Exception)
            {
                return BadRequest("Something wen wrong");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CityDTO>> Post([FromBody] CityDTO cityDTO)
        {
            var city = mapper.Map<City>(cityDTO);
            city = await Dependencies.CityRepository.Save(city);
            cityDTO = mapper.Map<CityDTO>(city);

            return Ok(cityDTO);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entitidade = await Dependencies.CityRepository.GetByIdAsync(id);
            if (entitidade == null) return NotFound($"There is no city with the id {id}");

            await Dependencies.CityRepository.Delete(entitidade);

            return NoContent();

        }
    }
}
