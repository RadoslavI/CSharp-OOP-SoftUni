using System;
using System.Collections.Generic;
using System.Text;

namespace vExtension
{
    public class Car : Vehicle
    {
        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value + 0.9; }
        
    }
}
