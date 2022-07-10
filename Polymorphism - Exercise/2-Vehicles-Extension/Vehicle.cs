using System;
using System.Collections.Generic;
using System.Text;

namespace vExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        public Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;            
            FuelConsumption = fuelConsumption;
        }

        public double TankCapacity { get; set; }
        
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            
            set 
            {
                if (value > TankCapacity)
                    fuelQuantity = 0;
                else
                fuelQuantity = value; 
            }
        }

        public virtual double FuelConsumption { get; set; }

        public virtual void Drive(double km)
        {
            FuelQuantity -= FuelConsumption * km;
        }

        public virtual void Refuel(double amount)
        {
            if (amount < TankCapacity && amount > 0)
            {
                FuelQuantity += amount;
            }
            else if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
        }

        public virtual bool CanDrive(double distance)
        {
            if (FuelQuantity >= FuelConsumption * distance)
            {
                return true;
            }
            return false;
        }
    }
}
