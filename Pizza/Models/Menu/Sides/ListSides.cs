using System;
using System.Collections.Generic;

namespace Pizza
{
    public abstract class ListSides: IListSides
    {
        protected List<string> listSides = new List<string>();
       

        protected void AddTolist(List<string> listKey)
        {
            foreach (var k in listKey)
            {
                string side = Name.GetNameConfig(k);
                listSides.Add(side);
            }
        }

        public void AddSideToList(List<String> listSides, string sideText)
        {            
            string name = HelpFinding.FindName(sideText);
            string price = HelpFinding.FindPrice(sideText);
        }
    }
}
