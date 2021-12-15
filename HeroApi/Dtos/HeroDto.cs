using System;
using System.Collections.Generic;

namespace Dtos
{
    public class HeroDto
    {
        public string Name { get; set; }
        public double PowerLevel { get; set; }
        public List<string> Powers { get; set; }
        public List<string> Weaknesses { get; set; }
        public string Birthplace { get; set; }
    }
}
