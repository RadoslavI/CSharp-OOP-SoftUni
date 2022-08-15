using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    //not sure if it is value or model!
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidF1CarModel, value));
                }

                model = value;
            }
        }

        public int Horsepower
        {
            get => horsepower;
            private set
            {
                if (value < 900 || value > 1050)
                {
                    //not sure if it is value or hp!
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }

                horsepower = value;
            }
        }
        public double EngineDisplacement
        {
            get => engineDisplacement;
            private set
            {
                if (value < 1.6 || value > 2.00)
                {
                    //not sure if it is value or hp!
                    throw new ArgumentException($"Invalid car engine displacement: {value}.");
                }

                engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return ((EngineDisplacement / Horsepower) * laps);
        }
    }
}
