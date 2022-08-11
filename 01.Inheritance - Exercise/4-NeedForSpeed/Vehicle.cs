using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public double FuelConsumption  { get; set; }

        public virtual double DefaultFuelConsumption { get; set; } = 1.25;


        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            Fuel = Fuel - (kilometers * DefaultFuelConsumption);
        }
    }
}
