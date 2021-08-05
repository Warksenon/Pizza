using System.Collections.Generic;

namespace Pizza
{
   public abstract class ListDishes
    {
        protected List<Dish> listDisches;
        protected Dish disch = new Dish();

        protected void AddDishesToList(List<string> key)
        {
            listDisches = new List<Dish>();
            foreach (var k in key)
            {
                disch = new Dish();
                string dishAndPrice = Name.GetNameConfig(k);
                string name = HelpFinding.FindName(dishAndPrice);              
                string price = HelpFinding.FindPrice(dishAndPrice);
                disch.Name = name;
                disch.Price = price;
                listDisches.Add(disch);
            }
        }    
    }
}
