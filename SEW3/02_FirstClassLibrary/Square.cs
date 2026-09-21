using System;
using System.Collections.Generic;
using System.Text;

namespace AreaCalculation
{
    public class Square
    {
        public double SideLength { get; set; }
        public Square(double sideLength)
        {
            SideLength = sideLength;
        }
        public double CalculateArea()
        {
            return SideLength * SideLength;
        }
    }
}