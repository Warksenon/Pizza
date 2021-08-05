using Pizza.Models.Menu.Sides;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Presenters.PresenterForm1.GetDishesAndSideDishForm1
{
    public class Form1SidesDish : Form1Quantity
    {
        public Form1SidesDish(FormMenu form) : base(form) { }
      
        public List<string> GetListSides()
        {
            List<string> list = new List<string>();
            foreach (object item in form.CheckedListBoxSide.CheckedItems)
            {               
                string side = item.ToString();               
                list.Add(side);
            }
            return list;
        }
    }
}
