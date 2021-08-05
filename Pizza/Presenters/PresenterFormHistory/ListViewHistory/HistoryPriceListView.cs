using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizza.Presenters.PresenterFormHistory
{
    public class HistoryPriceListView : IListGet<Dish>
    {
        List<Order> listOrder = new List<Order>();
        readonly FormHistory _form;

        public HistoryPriceListView ( FormHistory form )
        {
            _form = form;
        }

        public List<Dish> GetList ()
        {
            var listDishes = listOrder[_form.ListViewPrice.FocusedItem.Index].ListDishes;
            return listDishes;
        }

        public void SetList ( IListGet<Order> list )
        {
            ClearAllList();
            listOrder = list.GetList();
            foreach (var elemnt in listOrder)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(elemnt.PriceAll.ID));
                lvi.SubItems.Add( elemnt.PriceAll.Date );
                lvi.SubItems.Add( elemnt.PriceAll.Price );
                lvi.SubItems.Add( elemnt.PriceAll.Comments );
                _form.ListViewPrice.Items.Add( lvi );
            }
        }

        private void ClearAllList ()
        {
            _form.ListViewDishes.Items.Clear();
            _form.ListViewPrice.Items.Clear();
            listOrder.Clear();
        }
    }
}
