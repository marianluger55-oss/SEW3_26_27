using System;
using System.Collections.Generic;
using System.Text;


namespace AreaCalculation
{
    class Circle
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }   
    }
}
