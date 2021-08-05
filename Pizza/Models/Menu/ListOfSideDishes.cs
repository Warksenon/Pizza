using System.Collections.Generic;

namespace Pizza
{
    public class LoadListOfSideDishes
    {
        private readonly List<string> sideDishes = new List<string>();
        

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
                string sidedish = Name.GetNameConfig(k);
                sideDishes.Add(sidedish);
            }
        }
    }
}
