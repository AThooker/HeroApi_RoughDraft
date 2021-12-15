using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public abstract class SuperBeing
    {
        [Key]
        public int MetaId { get; set; }
        public string Name { get; set; }
        public double PowerLevel { get; set; }
        public List<string> Powers { get; set; }
        public List<string> Weaknesses { get; set; }
        public string Birthplace { get; set; }
        public bool ReadyToFight { get; set; }
        public Tuple<int, int> FightRecord { get; set; }
        public int Health { get; set; } = 100;
        public abstract string ActivatePower(string power);
        public abstract bool IsReadyToFight();
    }
}
