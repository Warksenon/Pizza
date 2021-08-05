using Pizza.Presenters.PresenterForm1.GetDishesAndSideDishForm1;
using Pizza.Presenters.PresenterForm1.Order;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizza.Presenters
{
    class Form1AddOrderListViewPresenters : Form1ListViewOrder, ILogic
    {
        Form1ListDishes lvDishes;
        Form1SidesDish chblSides;
        
        public Form1AddOrderListViewPresenters(FormMenu form1):base(form1)
        {                     
            lvDishes = new Form1ListDishes(form1);
            chblSides = new Form1SidesDish(form1);           
        }


        public void LogicSettings()
        {
            AddOrderToListView();
        }

        private void AddOrderToListView()
        {
            List<Dish> listDishes = lvDishes.GetListDishes();
            List<string> listSides = chblSides.GetListSides();
            string allSidesToGether = AddAllSides(listSides);

            foreach (var dish in listDishes)
            {
                ListViewItem lvi;
                if (HelpFinding.CheckStringIsEmpty(allSidesToGether))
                {
                    lvi = new ListViewItem(dish.Name);
                    lvi.SubItems.Add(allSidesToGether);
                    lvi.SubItems.Add(dish.Price);
                }
                else
                {
                    string priceAll = AddPriceDisheAndSide(listDishes, listSides);
                    lvi = new ListViewItem(dish.Name + " - " + dish.Price);
                    lvi.SubItems.Add(allSidesToGether);
                    lvi.SubItems.Add(priceAll);
                }

                lvOrder.ListViewOrder.Items.Add(lvi);
            }
        }

      

        private string AddAllSides(List<string> listSides)
        {
            string allSidesToGether = "";
            for(int i = 0; i < listSides.Count; i++ )
            {                
                allSidesToGether += listSides[i];
                if(i== listSides.Count)
                {
                    allSidesToGether += ".";
                }
                else
                {
                    allSidesToGether += ",";
                }
            }
           
            return allSidesToGether;
        }

        private string AddPriceDisheAndSide(List<Dish> listDishes, List<string> listSides)
        {
            double priceSides=0;
            double price;

            foreach (var side in listSides)
            {
                string textPrice = side;
                price = FindPrice(textPrice);
                priceSides += price; 
            }

            double priceDish = FindPrice(listDishes[0].Price);
            double priceAll = priceDish + priceSides;
            return priceAll + " zł";
        }

    }
}
