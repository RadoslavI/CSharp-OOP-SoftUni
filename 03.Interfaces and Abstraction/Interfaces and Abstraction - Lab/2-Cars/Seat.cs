using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    internal class Seat : ICar
    {
        private string v1;
        private string v2;

        public Seat(string v1, string v2)
        {
            Model = v1;
            Color = v2;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{Color} Seat {Model} ";
        }
    }
}
