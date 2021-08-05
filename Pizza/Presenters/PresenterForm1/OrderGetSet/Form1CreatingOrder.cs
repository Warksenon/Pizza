using Pizza.Presenters.PresenterForm1.Order;
using Pizza.View.Form1;
using System.Collections.Generic;

namespace Pizza
{
    class Form1CreatingOrder : Form1ListViewOrder
    {
        private static Order order = new Order();

        public Form1CreatingOrder(FormMenu form1) : base(form1) { }
 
        public Order  GetOrderFromListView()
        {            
            GetListDishesFromListViewOrder();
            AddPriceAllToOrder();
            GetComments();
            return order;
        }

        private void AddPriceAllToOrder()
        {
            double price = GetPricaAll();          
            order.PriceAll.Price = price + " zł";
        }

        private void GetComments()
        {
            order.PriceAll.Comments = form.TextBoxComments.Text;
        }

        private void GetListDishesFromListViewOrder()
        {
            var list = new List<Dish>();
            int counter = form.ListViewOrder.Items.Count;

            for (int i = 0; i < counter; i++)
            {
                list.Add(new Dish()
                {
                    Name = form.ListViewOrder.Items[i].SubItems[0].Text,
                    Sides = form.ListViewOrder.Items[i].SubItems[1].Text,
                    Price = form.ListViewOrder.Items[i].SubItems[2].Text
                });
            }

            order.ListDishes = list;
        }

        //public void SetCommentsAndDate(string comments)
        //{
        //    order.PriceAll.Comments = comments;
        //    order.PriceAll.Date = DateTime.Now.ToString();
        //}

        //public Order GetOrder()
        //{
        //    return order;
        //}





        //static string sendMesseg;
        //public void SubmitOrder()
        //{
        //    if (ChceckListViewOrderIsNotEpmty())
        //    {
        //        SetCommentsAndDate(form1Order.TextBoxComments.Text);
        //        SetListDishes(form1Order.ListViewOrder);
        //        //EmailMessage messeg = new EmailMessage(GetOrder());
        //     //   sendMesseg = messeg.WriteBill();
        //        if (form1Order.BackgroundWorker.IsBusy != true)
        //        {
        //            form1Order.BackgroundWorker.RunWorkerAsync();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Przetwarzanie danych proszę czekać");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Proszę wybrać produkt");
        //    }
        //}

        //private bool ChceckListViewOrderIsNotEpmty()
        //{
        //    if (form1Order.ListViewOrder.Items.Count > 0) return true;
        //    else return false;
        //}

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
