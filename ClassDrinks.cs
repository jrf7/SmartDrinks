using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDrinks
{
    internal class Drinks
    {
        public string Name { get; set; }
        public bool isCarbonated { get; set; }
        public Color Color { get; set; }

        public string Carbonated(bool isCarbonated)
        {
            return isCarbonated ? "carbonated" : "not carbonated";
        }

        public virtual string Description()
        {
            return "";
        }
    }

    class Beer : Drinks
    {
        public Decimal Alcohol { get; set; }

        public Beer(string strName, bool isCarbonted, Decimal fltAlcohol)
        {
            Name = strName;
            isCarbonated = isCarbonted;
            Alcohol= fltAlcohol;
            Color = Color.Blue;
        }

        public override string Description()
        {
            return Name + ", " + Carbonated(isCarbonated) + ", " + Alcohol + @"% alcohol.";
        }
    }
    class Juice : Drinks
    {
        public string Fruit { get; set; }

        public Juice(string strName, bool isCarbonted, string strFruit)
        {
            Name = strName;
            isCarbonated = isCarbonted;
            Fruit = strFruit;
            Color = Color.Purple;
        }

        public override string Description()
        {
            return Name + ", " + Carbonated(isCarbonated)+ ", made from "+Fruit+".";
        }
    }

    class Soda : Drinks
    {
        public Soda(string strName, bool isCarbonted)
        {
            Name = strName;
            isCarbonated = isCarbonted;
            Color = Color.Green;
        }

        public override string Description()
        {
            return Name + ", " + Carbonated(isCarbonated) + ".";
        }
    }

}
