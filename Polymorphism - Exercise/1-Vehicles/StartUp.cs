using System;

namespace _1_Vehicles
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            string[] truckInfo = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] commands = Console.ReadLine().Split();
                

                if (commands[0] == "Drive")
                {
                    double distance = double.Parse(commands[2]);
                    if (commands[1] == "Car")
                    {
                        if (car.CanDrive(distance))
                        {
                            Console.WriteLine($"Car travelled {distance} km");
                            car.Drive(distance);
                        }
                        else
                            Console.WriteLine("Car needs refueling");
                    }
                    else if (commands[1] == "Truck")
                    {
                        if (truck.CanDrive(distance))
                        {
                            Console.WriteLine($"Truck travelled {distance} km");
                            truck.Drive(distance);
                        }
                        else
                        Console.WriteLine("Truck needs refueling");
                    }
                }
                else if (commands[0] == "Refuel")
                {
                    double litres = double.Parse(commands[2]);
                    if (commands[1] == "Car")
                    {
                        car.Refuel(litres);
                    }
                    else if (commands[1] == "Truck")
                    {
                        truck.Refuel(litres);
                    }
                }

            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
