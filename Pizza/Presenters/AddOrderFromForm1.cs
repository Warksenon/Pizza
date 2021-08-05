using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizza
{
    public class AddOrderFromForm1
    {
        Order order = new Order();
       
        public double PriceCalculation(ListView list)
        {
            double priceOrder = 0;
            string priceDishes;

            if (!(list.Items == null))
            {
                int i = 0;
                foreach (var item in list.Items)
                {
                    priceDishes = list.Items[i].SubItems[2].Text;
                    priceDishes = priceDishes.Remove(priceDishes.IndexOf("zł"));
                    priceOrder += Convert.ToDouble(priceDishes);
                    i++;
                }
            }
            AddPriceAllToOrder(priceOrder);
            return priceOrder;
        }

        void AddPriceAllToOrder(double price)
        {
            order.PriceAll.Price = Convert.ToString(price);
            
        }

        public void SetListDenmark(ListView ListView)
        {          
                var list = new List<Dish>();
                
                if (!(ListView.Items == null))
                {
                    int i = 0;
                    foreach (var item in ListView.Items)
                    {
                        list.Add(new Dish()
                        {
                            Name = ListView.Items[i].SubItems[0].Text,
                            SidesDishes = ListView.Items[i].SubItems[1].Text,
                            Price = ListView.Items[i].SubItems[2].Text
                        });
                        i++;
                    }
                }
                order.ListDishes = list;         
        }

        public void SetCommentsAndDate( string comments)
        {
            order.PriceAll.Comments = comments;
            order.PriceAll.Date = DateTime.Now.ToString();
        }

        public int FindsPrice(string priceSide)
        {
            int start = priceSide.IndexOf("zł") - 2;
            priceSide = priceSide.Substring(start, 2);
            priceSide = priceSide.Trim();
            priceSide = priceSide.Replace("-", " ");
            return Convert.ToInt16(priceSide);
        }

        public Order GetOrder()
        {            
            return order;
        }

    }
}
