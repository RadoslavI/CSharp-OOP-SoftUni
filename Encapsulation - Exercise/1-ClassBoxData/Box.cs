using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1ClassBoxData
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;  
            Height = height;
        }
        private double Lenght
        {
            get { return lenght; }
            
            set 
            { 
                if (value <= 0)
                {
                    throw new ArgumentException($"Lenght cannot be zero or negative.");
                }

                lenght = value; 
            }
        }

        private double Width
        {
            get { return width; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }

                width = value;
            }
        }

        private double Height
        {
            get { return height; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }

                height = value;
            }
        }


        //        volume = lwh
        //lateral surface area = 2lh + 2wh
        //surface area = 2lw + 2lh + 2wh
        public double SurfaceArea()
        {
            var result = 2 * (Lenght * Width + Lenght * Height + Width * Height);
            return result;
        }

        public double LateralSurfaceArea()
        {
            var result = 2 * (Lenght * Height + Width * Height);
            return result;
        }

        public double Volume()
        {
            var result = (Lenght * Height * Width);
            return result;
        }

    }
}
