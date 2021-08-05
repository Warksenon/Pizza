using Pizza.Presenters.PresenterForm1.LoadDishesAndSideDishForm1;
using System.Collections.Generic;

namespace Pizza
{
    public class ListDrinks : ListDishes, IForm1Dishes
    {
        public List<Dish> LoadListDrinks()
        {
            List<string> key = new List<string> { "coffeePrice", "teaPrice", "colaPrice" };
            AddDishesToList(key);
            return listDisches;
        }

        public List<Dish> GetDishes()
        {
            return LoadListDrinks();
        }
    }
}
