using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FarmLib
{
    public class Farm
    {
        public string Name { get; set; }
        public List<Field> Fields { get; set; } = new List<Field>();


        public Farm(string Name)
        {
            this.Name = Name;
        }

        public void AddField(Field field)
        {
            Fields.Add(field);
        }
        
        public double TotalAreaHa()
        {
            double total = 0;

            foreach (Field field in Fields)
            {
                total += field.AreaHa;
            }
            return total;
        }
        public double TotalYieldTonnes()
        {
            double total = 0;
            foreach(Field field in Fields)
            {
                total += field.TotalYieldTonnes(); 
            }
            return total;
        }
    }
}
