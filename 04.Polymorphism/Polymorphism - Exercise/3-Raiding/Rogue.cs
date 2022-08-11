using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
            Power = 80;
        }

        public override int Power { get => base.Power; set => base.Power = 80; }

        //Rogue - "{Type} - {Name} hit for {Power} damage"

        public override string CastAbility()
        {
            return $"Rogue - {Name} hit for {Power} damage";
        }
    }
}
