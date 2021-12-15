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
    public class VilliansController : ControllerBase
    {
        private readonly HeroDbContext _context;
        public VilliansController(HeroDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateVillian(VillianCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var service = CreateVillianService();
            if (service.CreateVillian(model) == null)
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
        public async Task<ActionResult> GetVillianes()
        {
            var service = CreateVillianService();
            var villians = await service.GetVillians();
            return Ok(villians);

        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetVillianByName(string name)
        {
            var service = CreateVillianService();
            // var Villian = service.GetVillianByName(name);
            return Ok(await service.GetVillianByName(name));
        }

        public VillianService CreateVillianService()
        {
            return new VillianService(_context);
        }
    }
}