﻿using System;

namespace _1_Shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            IDrawable rect = new Rectangle(width, height);

            circle.Draw();
            rect.Draw();

        }
    }
}