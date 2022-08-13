using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            FullName = fullName;
            CanRace = false;
            //must initialise the car somehow maybe?...
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    //not sure if it is value or fullName!
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }

                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    //not sure if it is value or fullName!
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }

                car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins ++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
