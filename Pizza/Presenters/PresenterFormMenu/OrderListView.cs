using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Pizza.Presenters.PresenterFormMenu
{
    public class OrderListView : IListSet<Dish>, IElementGet<Order>, IPrice
    {
        private readonly Order order = new Order();
        private readonly FormMenu _form;

        public OrderListView ( FormMenu form )
        {
            _form = form;
        }

        public Order GetElement ()
        {
            return GetOrderFromListView();
        }

        private Order GetOrderFromListView ()
        {
            GetListDishesFromListViewOrder();
            AddPriceAllToOrder();
            GetComments();
            GetDate();
            return order;
        }

        private void AddPriceAllToOrder ()
        {
            double price = GetPricaAll();
            order.PriceAll.Price = price + "zł";
        }

        private void GetComments ()
        {
            order.PriceAll.Comments = _form.TextBoxComments.Text;
        }

        private void GetDate ()
        {
            order.PriceAll.Date = DateTime.Now.ToString();
        }

        private void GetListDishesFromListViewOrder ()
        {
            var list = new List<Dish>();
            int counter = _form.ListViewOrder.Items.Count;

            for (int i = 0; i < counter; i++)
            {
                list.Add( new Dish()
                {
                    Name = _form.ListViewOrder.Items [i].SubItems [0].Text,
                    Sides = _form.ListViewOrder.Items [i].SubItems [1].Text,
                    Price = _form.ListViewOrder.Items [i].SubItems [2].Text
                } );
            }

            order.ListDishes = list;
        }

        public void SetList ( List<Dish> elements )
        {
            AddOrderToListView( elements );
        }

        private void AddOrderToListView ( List<Dish> listDishes )
        {
            foreach (var element in listDishes)
            {
                ListViewItem lvi;
                lvi = new ListViewItem( element.Name );
                lvi.SubItems.Add( element.Sides );
                lvi.SubItems.Add( element.Price );

                _form.ListViewOrder.Items.Add( lvi );
            }
        }

        public double FindPriceAndConvertToDoubel ( string dish )
        {
            double price = 0;
            try
            {
                string textPrice = HelpFinding.FindPrice(dish);
                textPrice = textPrice.Replace( "zł", "" );
                price = Convert.ToDouble( textPrice );
            }
            catch (Exception e)
            {
                RecordOfExceptions.Save( Convert.ToString( e ), "Form1OrderPresenter - FindPrice" );
            }
            return price;
        }

        public double GetPricaAll ()
        {
            double priceAll = 0;
            double price;
            StringBuilder textPrice = new StringBuilder();
            try
            {
                for (int i = 0; i < _form.ListViewOrder.Items.Count; i++)
                {
                    textPrice.Clear();
                    textPrice.Append( _form.ListViewOrder.Items [i].SubItems [2].Text );
                    price = FindPriceAndConvertToDoubel( textPrice.ToString() );
                    priceAll += price;
                }
            }
            catch (Exception e)
            {
                RecordOfExceptions.Save( Convert.ToString( e ), "Form1OrderPresenter - GetPricaAll" );
            }
            return priceAll;
        }

    }
}
