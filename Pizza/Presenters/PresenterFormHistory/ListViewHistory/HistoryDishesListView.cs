using System;
using System.Windows.Forms;

namespace Pizza.Presenters.PresenterFormHistory
{
    public class HistoryDishesListView
    {

        private readonly FormHistory _form;

        public HistoryDishesListView ( FormHistory form )
        {
            _form = form;
        }

        public void SetList ( IListGet<Dish> list )
        {
            _form.ListViewDishes.Items.Clear();
            var listDish = list.GetList();
            foreach (var dish in listDish)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(dish.Id));
                lvi.SubItems.Add( dish.Name );
                lvi.SubItems.Add( dish.Price );
                lvi.SubItems.Add( dish.Sides );
                _form.ListViewDishes.Items.Add( lvi );
            }
        }
    }
}
