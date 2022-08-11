using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }
        public double DrivenDistance { get; set; } = 0;

        public virtual void Drive(double km)
        {
            FuelQuantity -= FuelConsumption * km;
            DrivenDistance += km;
            //Console.WriteLine($"Car/Truck travelled {km} km");
        }

        public virtual void Refuel(double Litres)
        {
            FuelQuantity += Litres;
        }

        public virtual bool CanDrive(double distance)
        {
            if (FuelQuantity >= FuelConsumption * distance)
            {
                return true;
            }
           // Console.WriteLine("Car / Truck needs refueling");
            return false;
        }
    }
}
