using System.Collections.Generic;

namespace Pizza
{
    public class ListOfDishes
    {
        List<Dish> listDisches; 
        Dish disch = new Dish();
        Name name = new Name();

        public List<Dish> LoadListPizza()
        {            
            List<string> key = new List<string> { "marghPrice", "vegetPrice", "toscaPrice", "venecPrice" };
            AddDishesToList(key);  
            return listDisches;
        }

        public List<Dish> LoadListMainDish()
        {

            List<string> key = new List<string> { "schnitzelPrice", "fishPrice", "potatoPrice"};
            AddDishesToList(key);
            return listDisches;
        }

        public List<Dish> LoadListSoups()
        {
            List<string> key = new List<string> { "tomatoPrice", "chickenSoupPrice" };
            AddDishesToList(key);
            return listDisches;
        }

        public List<Dish> LoadListDrinks()
        {

            List<string> key = new List<string> { "coffeePrice", "teaPrice", "colaPrice" };
            AddDishesToList(key);
            return listDisches;
        }


        private void AddDishesToList(List<string> key)
        {
            listDisches = new List<Dish>();
            foreach (var k in key)
            {
                disch = new Dish();
                string dishAndPrice = name.GetNameConfig(k);
                disch.Name = FindNameDish(dishAndPrice);
                disch.Price = FindPrice(dishAndPrice);
                listDisches.Add(disch);
            }
        }

        private string FindNameDish(string nameAndPrice)
        {
            int index = nameAndPrice.IndexOf("-") - 1;
            if (index == -1)
            {
                return "";
            }
            else
            {
                string sdish = nameAndPrice.Substring(0, index);
                return sdish;
            }
        }

        private string FindPrice(string nameAndPrice)
        {
            int index = nameAndPrice.IndexOf("-") + 1;
            if (index == -1)
            {
                return "";
            }
            else
            {
                string price = nameAndPrice.Substring(index);
                return price;
            }
        }
    }
}
