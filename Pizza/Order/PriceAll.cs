using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    public class PriceAll
    {
        private HelpFinding help = new HelpFinding();
        string date;
        string comments;       
        string price;
        Int64 id;
        
        public Int64 ID
        {
            get {return id;}
            set{id = value;}
        }
        public string Price
        {
            get {return price = help.CheckIsNotNull(price); }
            set { price = help.CheckIsNotNull(value); }
        }
        public string Date
        {
            get { return help.CheckIsNotNull(date); }
            set { date = help.CheckIsNotNull(value); }
        }
        public string Comments
        {
            get { return help.CheckIsNotNull(comments); }
            set { comments = help.CheckIsNotNull(value);  }
        }
        
    }
}
