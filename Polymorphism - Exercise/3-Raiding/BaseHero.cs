using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }
       
        public virtual string Name { get; private set; }
        public virtual int Power { get;  set; }
        
        public virtual string CastAbility()
        {
            return "TOADD";
        }
    }
}
