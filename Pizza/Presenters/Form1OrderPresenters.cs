using Pizza.Models.Order;
using Pizza.Presenters.PresenterForm1.GetDishesAndSideDishForm1;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizza.Presenters
{
    class Form1OrderPresenters
    {
        Form1ListDishes lvDishes;
        Form1SidesDish chblSides;

        public Form1OrderPresenters(Form1 form1)
        {                     
            lvDishes = new Form1ListDishes(form1);
            chblSides = new Form1SidesDish(form1);
        }

        public void AddOrderToListView()
        {

            List<Dish> listDishes = lvDishes.GetListDishes();
            List<Side> listSides = chblSides.GetListSides();

            if (CheckNumberTextViewDishes() > 0)
            {
                int x = CheckListDishesSelectedItem();
                Dish dish = new Dish
                {
                    Name = loadDishes.ListViewDishes.Items[x].SubItems[0].Text,
                    Price = loadDishes.ListViewDishes.Items[x].SubItems[1].Text
                };

                string allSidesToGether = AddAllSides(listSides);
                for (int i = 0; i <  i++)
                {
                    ListViewItem lvi;
                    
                    lvi = new ListViewItem(dish.Name);
                    lvi.SubItems.Add();
                    lvi.SubItems.Add(dish.Price);                                       
                    lvi = new ListViewItem(dish.Name + " -" + dish.Price);
                    lvi.SubItems.Add(AddAllSides());
                    lvi.SubItems.Add(PriceDisheAndSide(dish.Price));
                    
                    form1Order.ListViewOrder.Items.Add(lvi);
                }
            }
        }

       

        private string AddAllSides(List<Side> listSides)
        {
            string allSidesToGether = "";
            for(int i = 0; i<listSides.Count; i++ )
            {
                string name = listSides[i].Name;
                string price = listSides[i].Price;
                allSidesToGether += name + " " + price;
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

       

      

        private string PriceDisheAndSide(string priceDish)
        {
            string priceSide;
            int priceAll = FindsPrice(priceDish);

            foreach (object item in loadSides.CheckedListBoxSide.CheckedItems)
            {
                priceSide = item.ToString();
                priceAll += FindsPrice(priceSide);
            }
            return priceAll + "zł";
        }

        private int FindsPrice(string priceSide)
        {
            int start = priceSide.IndexOf("-");
            if (start > 0) { priceSide = priceSide.Substring(start); }
            priceSide = priceSide.Replace("-", "");
            priceSide = priceSide.Replace("zł", "");
            priceSide = priceSide.Trim();
            return Convert.ToInt16(priceSide);
        }

        public void LabelPrice()
        {

            form1Order.LabelPrice.Text = "Cena: " + PriceCalculation(form1Order.ListViewOrder).ToString() + "zł";
        }

        private double PriceCalculation(ListView list)
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

        static readonly Order order = new Order();

        void AddPriceAllToOrder(double price)
        {
            order.PriceAll.Price = Convert.ToString(price);

        }


        public void SetListDishes(ListView ListView)
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
                     //   SidesDishes = ListView.Items[i].SubItems[1].Text,
                        Price = ListView.Items[i].SubItems[2].Text
                    });
                    i++;
                }
            }
            order.ListDishes = list;
        }

        public void SetCommentsAndDate(string comments)
        {
            order.PriceAll.Comments = comments;
            order.PriceAll.Date = DateTime.Now.ToString();
        }

        public Order GetOrder()
        {
            return order;
        }

        //static string sendMesseg;
        public void SubmitOrder()
        {
            if (ChceckListViewOrderIsNotEpmty())
            {
                SetCommentsAndDate(form1Order.TextBoxComments.Text);
                SetListDishes(form1Order.ListViewOrder);
                //EmailMessage messeg = new EmailMessage(GetOrder());
             //   sendMesseg = messeg.WriteBill();
                if (form1Order.BackgroundWorker.IsBusy != true)
                {
                    form1Order.BackgroundWorker.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Przetwarzanie danych proszę czekać");
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać produkt");
            }
        }

        private bool ChceckListViewOrderIsNotEpmty()
        {
            if (form1Order.ListViewOrder.Items.Count > 0) return true;
            else return false;
        }

        //private bool SendEmail(string message)
        //{
        //   // Email email = new Email();
        //    return email.SendEmail(message);
        //}

        //public void SendEmailAndSaveOrder()
        //{
        //    Save save = new Save();
        //    if (SendEmail(sendMesseg))
        //    {
        //        save.SaveOrder(Save.ChoiceSaveOrder.Txt, GetOrder());
        //        save.SaveOrder(Save.ChoiceSaveOrder.Sql, GetOrder());
        //    }
        //    else
        //    {
        //        MessageBox.Show("Wysłanie wiadomości nie powiodło się. Problem z adres e-mail lub z połaczeniem internetowym");
        //    }
        //}

    }
}
