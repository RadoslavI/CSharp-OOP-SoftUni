using System;
using System.Collections.Generic;
using System.Text;

namespace vExtension
{
    public class Truck : Vehicle
    {
        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value + 1.6; }

        public override void Refuel(double amount)
        {
            if (amount < TankCapacity && amount > 0)
            {
                FuelQuantity += amount * 0.95;
            }
            else if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
        }

    }
}
