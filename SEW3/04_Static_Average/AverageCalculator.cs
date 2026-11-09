using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Static_Average
{
    class AverageCalculator
    {
        public static double CalculateAverage()
        {
            Console.WriteLine("Berechne den Mittelwert der eingegebenen Zahl. Beliebiges Zeichen für Ende");
            double inputVaraible; 
            double sum = 0;
            int count = 0;

            while(true)
            {
                Console.WriteLine("Bitte geben Sie eine Zahl ein: ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out inputVaraible)) // Versuchen den Input in eine Zahl umzuwandeln. Wenn es funktioniert, wird der Wert in inputVariable gespeichert und true zurückgegeben. Wenn es nicht funktioniert, wird false zurückgegeben.
                {
                    sum += inputVaraible;
                    count++;
                }
                else
                {
                    break;
                }
            }
            
            return sum / count;

        }
    }
}