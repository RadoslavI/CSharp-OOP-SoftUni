using System;
using System.Collections.Generic;
using System.Text;

namespace vExtension
{
    public class Bus : Vehicle
    {
        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public bool isEmpty { get; set; }

        public override double FuelConsumption
            => this.isEmpty
            ? base.FuelConsumption
            : base.FuelConsumption + 1.4;

    }
}
