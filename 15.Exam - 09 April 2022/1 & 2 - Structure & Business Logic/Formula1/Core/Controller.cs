using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (pilotRepository.FindByName(pilotName) == null
                || pilotRepository.FindByName(pilotName).Car != null)
            {
                throw new InvalidOperationException(
                    $"Pilot {pilotName} does not exist or has a car.");
            }
            if (carRepository.FindByName(carModel) == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            var car = carRepository.FindByName(carModel);
            var pilot = pilotRepository.FindByName(pilotName);
            pilot.AddCar(car);
            carRepository.Remove(car);

            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            if (pilotRepository.FindByName(pilotFullName) == null
                || pilotRepository.FindByName(pilotFullName).CanRace == false
                || raceRepository.FindByName(raceName).Pilots.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            var pilot = pilotRepository.FindByName(pilotFullName);
            raceRepository.FindByName(raceName).AddPilot(pilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type == "Ferrari")
            {
                if (carRepository.FindByName(model) != null)
                {
                    throw new InvalidOperationException(
                        $"Formula one car {model} is already created.");
                }

                carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
            }
            else if (type == "Williams")
            {
                if (carRepository.FindByName(model) != null)
                {
                    throw new InvalidOperationException(
                        $"Formula one car {model} is already created.");
                }

                carRepository.Add(new Williams(model, horsepower, engineDisplacement));
            }
            else
            {
                throw new InvalidOperationException(
                    $"Formula one car type {type} is not valid.");
            }

            return $"Car { type }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            pilotRepository.Add(new Pilot(fullName));
            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            raceRepository.Add(new Race(raceName, numberOfLaps));
            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            var printPilots = pilotRepository
                .Models
                .OrderByDescending(x => x.NumberOfWins)
                .ToList();

            foreach (var pilot in printPilots)
            {
                sb.AppendLine($"Pilot { pilot.FullName } has { pilot.NumberOfWins } wins.");
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            List<IRace> executedRaces = raceRepository
                .Models
                .Where(x => x.TookPlace)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var race in executedRaces)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd(); ;
        }

        public string StartRace(string raceName)
        {
            var currRace = raceRepository.FindByName(raceName);

            if (currRace == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (currRace.Pilots.Count() < 3)
            {
                throw new InvalidOperationException(
                    $"Race {raceName} cannot start with less than three participants.");
            }
            if (currRace.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            var grid = currRace.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(currRace.NumberOfLaps))
                .Take(3)
                .ToList();

            currRace.TookPlace = true;

            grid.First().WinRace();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Pilot {grid.First().FullName} wins the {raceName} race.");
            grid.Remove(grid.First());
            sb.AppendLine($"Pilot {grid.First().FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {grid.Last().FullName} is third in the {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
