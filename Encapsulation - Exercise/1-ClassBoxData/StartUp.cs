using System;

namespace _1ClassBoxData
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Box box = null;

            try
            {
                 box = new Box(lenght, width, height);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Surface Area - " + "{0:0.00}", box.SurfaceArea());
            Console.WriteLine("Lateral Surface Area - " + "{0:0.00}", box.LateralSurfaceArea());
            Console.WriteLine($"Volume - " + "{0:0.00}", box.Volume());
        }
    }
}
