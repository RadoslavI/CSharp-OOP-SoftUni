using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
            Power = 100;
        }

        public override int Power { get => base.Power; set => base.Power = 100; }

        public override string CastAbility()
        {
            return $"Paladin - {Name} healed for {Power}";
        }
    }
}
