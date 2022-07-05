using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar, ICar
    {
        private string v1;
        private string v2;
        private int v3;

        public Tesla(string v1, string v2, int v3)
        {
            Model = v1;
            Color = v2;
            Battery = v3;
        }

        public int Battery { get; set; }
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
            return $"{this.Color} Tesla {Model} ";
        }
    }
}
