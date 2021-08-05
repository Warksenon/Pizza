using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    
    public class Order 
    {    
        private List<Dish> listDisch;
        private PriceAll priceAll;

        public Order()
        {
            listDisch = new List<Dish>();
            priceAll = new PriceAll();           
        }

        public PriceAll PriceAll
        {
            get{ return priceAll; }
            set { priceAll = value; }
        }

        public List<Dish> ListDishes
        {
            get { return listDisch; }
            set { listDisch = value; }
        }

        public void AddDishToListDisch(Dish d)
        {
            listDisch.Add(d);
        }

    }
}
