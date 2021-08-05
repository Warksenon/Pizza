using System.Collections.Generic;

namespace Pizza
{
    public class LoadListOfSideDishes
    {
        List<string> sideDishes = new List<string>();
        Name name = new Name();

        public List<string> LoadSidePizza()
        {
            List<string> key = new List<string> { "doubelCheesePrice", "salamiPrice", "hamPrice", "mushroomsPrice" };
            AddTolist(key);
            return sideDishes;
        }

        public List<string> LoadSideMainDish()
        {
            List<string> key = new List<string> { "barPrice", "setOfSaucesPrice"};
            AddTolist(key);
            return sideDishes;
        }

        void AddTolist (List<string> key)
        {
            foreach(var k in key)
            {
                string sidedish = name.GetNameConfig(k);
                sideDishes.Add(sidedish);
            }
        }
    }
}
