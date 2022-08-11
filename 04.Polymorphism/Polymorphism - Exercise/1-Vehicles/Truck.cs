using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value + 1.6; }

        public override void Refuel(double Litres)
        {
            base.Refuel(Litres * 0.95);
        }

    }
}
