using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            Power = 80;
        }

        public override int Power { get => base.Power; set => base.Power = 80; }
        //Druid - "{Type} - {Name} healed for {Power}"
        public override string CastAbility()
        {
            return $"Druid - {Name} healed for {Power}";
        }
    }
}
