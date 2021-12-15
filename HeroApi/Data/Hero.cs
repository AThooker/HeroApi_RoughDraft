using System;
using System.Collections.Generic;

namespace Data
{
    public class Hero : SuperBeing
    {
        //Hero's id
        public int HeroId { get; set; }

        //Choosing from list of powers, and activating that power, based available health
        public override string ActivatePower(string power)
        {
            return "Hero Power activated: " + power;
        }

        public override bool IsReadyToFight()
        {
            if(ReadyToFight == true)
            {
                return true;
            }
            return false;
        }
        // public Hero(int metaId, int heroId, string name, List<string> powers, double powerLevel,  List<string> weaknesses, string birthplace, bool readyToFight)
        // {
        //     metaId = MetaId;
        //     heroId = HeroId;
        //     name = Name;
        //     powers = Powers;
        //     powerLevel = PowerLevel;
        //     weaknesses = Weaknesses;
        //     birthplace = Birthplace;
        //     ReadyToFight = ReadyToFight;
        // }
    }
}