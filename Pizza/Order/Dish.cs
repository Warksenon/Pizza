using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    public class Dish
    {
        private HelpFinding help = new HelpFinding();
        private Int64 idPrice;
        private string name;
        private string sidesDishes;
        private string price;

        public Int64 IdPrice
        {
            get { return idPrice; }
            set{ idPrice = value ;}
        }
        public string Price
        {
            get { return help.CheckIsNotNull(price); }
            set { price = help.CheckIsNotNull(value);}
        }
        public string Name
        {
            get { return help.CheckIsNotNull(name); }
            set { name = help.CheckIsNotNull(value); }
        }
        public string SidesDishes
        {
            get { return help.CheckIsNotNull(sidesDishes);}
            set { sidesDishes= help.CheckIsNotNull(value);}
        }

    }
}


