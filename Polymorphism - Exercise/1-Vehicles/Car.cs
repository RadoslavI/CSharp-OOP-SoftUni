using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value + 0.9; }
        

    }
}
