using Pizza.Presenters.PresenterForm1.LoadDishesAndSideDishForm1;
using System.Collections.Generic;

namespace Pizza
{
    public class ListSidesMainDishes : ListSides, IForm1Sides
    {
        private List<string> LoadSideMainDish()
        {
            List<string> listKey = new List<string> { "barPrice", "setOfSaucesPrice" };
            AddTolist(listKey);

            return listSides;
        }

        public List<string> GetSides()
        {
            return LoadSideMainDish();
        }
    }
}
