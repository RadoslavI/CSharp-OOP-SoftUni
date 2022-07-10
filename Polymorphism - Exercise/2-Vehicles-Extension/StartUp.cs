using System;

namespace vExtension
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Truck truck = null;
            Car car = null;
            Bus bus = null;

            for (int i = 0; i < 3; i++)
            {
                string[] vehicleInfo = Console.ReadLine().Split();
                double fuelQuantity = double.Parse(vehicleInfo[1]);
                double fuelConsumption = double.Parse(vehicleInfo[2]);
                double tankCapacity = double.Parse(vehicleInfo[3]);


                if (vehicleInfo[0] == "Car")
                {
                    car = new Car(tankCapacity, fuelQuantity, fuelConsumption);
                }
                else if (vehicleInfo[0] == "Truck")
                {
                    truck = new Truck(tankCapacity, fuelQuantity, fuelConsumption);
                }
                else if (vehicleInfo[0] == "Bus")
                {
                    bus = new Bus(tankCapacity, fuelQuantity, fuelConsumption);
                }
                else
                    return;
            }

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
                    else if (commands[1] == "Bus")
                    {
                        bus.isEmpty = false;
                        if (bus.CanDrive(distance))
                        {
                            Console.WriteLine($"Bus travelled {distance} km");
                            bus.Drive(distance);
                        }
                        else
                            Console.WriteLine("Bus needs refueling");
                    }
                }
                else if (commands[0] == "DriveEmpty")
                {
                    double distance = double.Parse(commands[2]);

                    if (commands[1] == "Bus")
                    {
                        bus.isEmpty = true;
                        if (bus.CanDrive(distance))
                        {
                            Console.WriteLine($"Bus travelled {distance} km");
                            bus.Drive(distance);
                        }
                        else
                            Console.WriteLine("Bus needs refueling");
                    }
                }
                
                else if (commands[0] == "Refuel")
                {
                    try
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
                        else if (commands[1] == "Bus")
                        {
                            bus.Refuel(litres);
                        }
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }                   
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
