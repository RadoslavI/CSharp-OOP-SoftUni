using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Wild_Farm
{
    public class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }

        //"{Type} {Name} {Weight} {WingSize}"
        
    }
}
