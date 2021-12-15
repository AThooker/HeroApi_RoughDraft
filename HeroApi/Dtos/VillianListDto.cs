using System;

namespace Dtos
{
    public class VillianListDto
    {
        public string Name { get; set; }
        public double PowerLevel { get; set; }
        public string Birthplace { get; set; }
        public Tuple<int, int> FightRecord { get; set; }
    }
}