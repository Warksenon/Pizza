using System.Collections.Generic;

using Pizza.Models.Menu.ListDishesAndSides;

namespace Pizza
{
    public class ListDishes : ListName, IListGet<Dish>, IListSet<string>
    {
        private List<Dish> listDisches = new List<Dish>();
        private Dish disch = new Dish();

        private void AddDishesToList ( List<string> key )
        {
            listDisches = new List<Dish>();

            foreach (var k in key)
            {
                disch = new Dish();
                string dishAndPrice = Name.GetNameConfig(k);
                string name = FindName(dishAndPrice);
                string price = HelpFinding.FindPrice(dishAndPrice);
                disch.Name = name;
                disch.Price = price;
                listDisches.Add( disch );
            }
        }

        public List<Dish> GetList ()
        {
            return listDisches;
        }

        public void SetList ( List<string> key )
        {
            AddDishesToList( key );
        }
    }
}
