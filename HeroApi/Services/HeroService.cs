using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Dtos;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class HeroService
    {
        private HeroDbContext _ctx;
        public HeroService(HeroDbContext ctx)
        {
            _ctx = ctx;
        }
        //Create authentication for service layer 
        //maybe Guid, maybe not, maybe Okta.... 

        public async Task<int> CreateHero(HeroDto model)
        {
            var entity = new Hero()
            {
                Name = model.Name,
                Powers = model.Powers,
                PowerLevel = model.PowerLevel,
                Weaknesses = model.Weaknesses,
                Birthplace = model.Birthplace
            };
            _ctx.Heroes.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity.HeroId;
        }

        public async Task<List<HeroesListDto>> GetHeroes()
        {
            var heroes = _ctx.Heroes
                        .Select(
                            h => new HeroesListDto
                            {
                                Name = h.Name,
                                PowerLevel = h.PowerLevel,
                                Birthplace = h.Birthplace,
                                FightRecord = h.FightRecord
                            }
                        );
            return await heroes.ToListAsync();
        }

        public async Task<HeroDetailDto> GetHeroByName(string name)
        {
            var heroByName = await _ctx.Heroes.SingleAsync(h => h.Name == name);
            var heroDto = new HeroDetailDto
            {
                Name = heroByName.Name,
                PowerLevel = heroByName.PowerLevel,
                Powers = new PowersDto
                {
                    PowerOne = heroByName.Powers[0],
                    PowerTwo = heroByName.Powers[1],
                    PowerThree = heroByName.Powers[2],
                    PowerFour = heroByName.Powers[3],
                    PowerFive = heroByName.Powers[4]
                },
                Weaknesses = new WeaknessesDto
                {
                    WeaknessOne = heroByName.Weaknesses[0],
                    WeaknessTwo = heroByName.Weaknesses[1],
                    WeaknessThree = heroByName.Weaknesses[2],
                    WeaknessFour = heroByName.Weaknesses[3],
                    WeaknessFive = heroByName.Weaknesses[4]
                },
                FightRecord = heroByName.FightRecord
            };
            return heroDto;
        }

    }
}
