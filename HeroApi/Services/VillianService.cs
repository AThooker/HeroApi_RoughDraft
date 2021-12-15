using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Dtos;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    //Look into using AutoMapper instead of hard coding all properties to Dtos
    public class VillianService
    {
        private HeroDbContext _ctx;
        public VillianService(HeroDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> CreateVillian(VillianCreateDto model)
        {
            var villian = new Villian
            {
                Name = model.Name,
                PowerLevel = model.PowerLevel,
                Powers = model.Powers,
                Weaknesses = model.Weaknesses,
                Birthplace = model.Birthplace
            };
            
            try
            {
                await _ctx.Villians.AddAsync(villian);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
        public async Task<List<VillianListDto>> GetVillians()
        {
            var villians = _ctx.Villians
                            .Select( v => new VillianListDto
                            {
                                Name = v.Name,
                                PowerLevel = v.PowerLevel,
                                Birthplace = v.Birthplace,
                                FightRecord = v.FightRecord,
                            });
            return await villians.ToListAsync();
        }
        public async Task<VillianDetailDto> GetVillianByName(string name)
        {
            var villian = await _ctx.Villians.SingleAsync(v => v.Name == name);
            var villianDto = new VillianDetailDto
            {
                Name = villian.Name,
                PowerLevel = villian.PowerLevel,
                Powers = new PowersDto
                {
                    PowerOne = villian.Powers[0],
                    PowerTwo = villian.Powers[1],
                    PowerThree = villian.Powers[2],
                    PowerFour = villian.Powers[3],
                    PowerFive = villian.Powers[4]
                },
                Weaknesses = new WeaknessesDto
                {
                    WeaknessOne = villian.Weaknesses[0],
                    WeaknessTwo = villian.Weaknesses[1],
                    WeaknessThree = villian.Weaknesses[2],
                    WeaknessFour = villian.Weaknesses[3],
                    WeaknessFive = villian.Weaknesses[4]
                },
                FightRecord = villian.FightRecord
            };
            return villianDto;
        }
    }
}