using Pizza.Presenters.PresenterForm1.LoadDishesAndSideDishForm1;
using System.Collections.Generic;

namespace Pizza
{
    public class ListSoups : ListDishes, IForm1Dishes
    {
        private List<Dish> LoadListSoups()
        {
            List<string> key = new List<string> { "tomatoPrice", "chickenSoupPrice" };
            AddDishesToList(key);
            return listDisches;
        } 

        public List<Dish> GetDishes()
        {
            return LoadListSoups();
        }
    }
}
