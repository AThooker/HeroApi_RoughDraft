using System;

namespace Dtos
{
    public class VillianDetailDto
    {
        public string Name { get; set; }
        public string Birthplace { get; set; }
        public double PowerLevel { get; set; }
        public PowersDto Powers { get; set; }
        public WeaknessesDto Weaknesses { get; set; }
        public Tuple<int, int> FightRecord { get; set; }
    }
}