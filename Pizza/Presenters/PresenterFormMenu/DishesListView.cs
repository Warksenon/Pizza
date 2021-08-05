using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizza.Presenters.PresenterFormMenu
{
    public class DishesListView : IElementGet<Dish>, IListSet<Dish>
    {
        private readonly FormMenu _form;

        public DishesListView ( FormMenu form )
        {
            _form = form;
        }

        public Dish GetElement ()
        {
            return GetSelektedDish();
        }

        private int indexSelect;
        private Dish GetSelektedDish ()
        {
            ChecktDishSelectedItem();
            Dish dish = new Dish();
            try
            {
                dish.Name = _form.ListViewDishes.Items [indexSelect].SubItems [0].Text;
                dish.Price = _form.ListViewDishes.Items [indexSelect].SubItems [1].Text;
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
            }

            return dish;
        }

        private void ChecktDishSelectedItem ()
        {
            try
            {
                indexSelect = _form.ListViewDishes.FocusedItem.Index;
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
            }
        }

        public void SetIndexSelecteItem ( int index )
        {
            indexSelect = index;
        }

        public void SetList ( List<Dish> listDisch )
        {
            AddDishesToListView( listDisch );
        }

        private void AddDishesToListView ( List<Dish> listDisch )
        {
            _form.ListViewDishes.Items.Clear();
            foreach (var disch in listDisch)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(disch.Name));
                lvi.SubItems.Add( disch.Price );
                _form.ListViewDishes.Items.Add( lvi );
            }
        }

    }
}
