using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace FarmLib
{
    public class Field
    {
        public string name;
        public double AreaHa;
        public string Crop;
        public double YieldDtPerHa;

        // Konstruktor
        public Field(string name, double AreaHa, string Crop, double YieldDtPerHa)
        {
            this.name = name;
            this.AreaHa = AreaHa;
            this.Crop = Crop;
            this.YieldDtPerHa = YieldDtPerHa;
        }

        // Liefert die Fläche in m²
        public double AreaInSquareMeters()
        {
            return AreaHa * 10000;
        }

        public double TotalYieldTonnes()
        { 
            return AreaHa * DecitonnesToTonnes();
        }
        public double DecitonnesToTonnes()
        {
            return YieldDtPerHa / 10; 
        }
    }
}
