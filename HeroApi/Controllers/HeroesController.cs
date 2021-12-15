using System.Threading.Tasks;
using Data;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace HeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly HeroDbContext _context;
        public HeroesController(HeroDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateHero(HeroDto model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var service = CreateHeroService();
            if (service.CreateHero(model) == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            };
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();

        }
        [HttpGet]
        public async Task<ActionResult> GetHeroes()
        {
            var service = CreateHeroService();
            var heroes = await service.GetHeroes();
            return Ok(heroes);

        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetHeroByName(string name)
        {
            var service = CreateHeroService();
            // var hero = service.GetHeroByName(name);
            return Ok(await service.GetHeroByName(name));
        }

        public HeroService CreateHeroService()
        {
            return new HeroService(_context);
        }
    }
}