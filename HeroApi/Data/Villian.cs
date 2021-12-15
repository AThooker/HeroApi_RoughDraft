using System.Collections.Generic;

namespace Data
{
    public class Villian : SuperBeing
    {
        //Villian's id
        public int VillianId { get; set; }

        //Choosing from list of powers, and activating that power, based available health
        public override string ActivatePower(string power)
        {
            return "Villian Power activated: " + power;
        }

        public override bool IsReadyToFight()
        {
            if(ReadyToFight == true)
            {
                return true;
            }
            return false;
        }
        // public Villian(int metaId, int villianId, string name, List<string> powers, double powerLevel,  List<string> weaknesses, string birthplace, bool readyToFight)
        // {
        //     metaId = MetaId;
        //     villianId = VillianId;
        //     name = Name;
        //     powers = Powers;
        //     powerLevel = PowerLevel;
        //     weaknesses = Weaknesses;
        //     birthplace = Birthplace;
        //     ReadyToFight = ReadyToFight;
        // }
    }
}