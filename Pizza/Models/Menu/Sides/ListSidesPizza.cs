using Pizza.Presenters.PresenterForm1.LoadDishesAndSideDishForm1;
using System.Collections.Generic;

namespace Pizza
{
    public class ListSidesPizza : ListSides, IForm1Sides
    {

        public List<string> LoadSidePizza()
        {
            List<string> listKey = new List<string> { "doubelCheesePrice", "salamiPrice", "hamPrice", "mushroomsPrice" };
            AddTolist(listKey);

            return listSides;
        }

        public List<string> GetSides()
        {
            return LoadSidePizza();
        }
    }
}
