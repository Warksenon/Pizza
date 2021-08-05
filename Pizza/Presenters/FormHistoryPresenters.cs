using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Pizza.Models.SqlLite;
using Pizza.SqlLite;

namespace Pizza.Presenters
{

    class FormHistoryPresenters
    {
        FormHistory form;
        List<Order> orderList = new List<Order>();
        readonly LoadOrder load = new LoadOrder();

        public FormHistoryPresenters(FormHistory form)
        {
            this.form = form;
        }

        public void CopyDataFromFilesTxt()
        {
            SaveHistory save = new SaveHistory();
            List<Order> listOrder = new List<Order>();

            listOrder = load.LoadOrderList(new LoadingFilesTxt());
            save.SaveList(new SaveHistorySQL(listOrder));
        }

        public void CopyDataFromSQL()
        {
            SaveHistory save = new SaveHistory();
            List<Order> listOrder = new List<Order>();

            listOrder = load.LoadOrderList(new LoadHistorySQL());
            save.SaveList(new SaveFiles(listOrder));
        }

        public void LoadHistroyFromTxt()
        {
            ClearAllList();
            orderList = load.LoadOrderList(new LoadingFilesTxt());
            LoadLVPriceAll();
        }

        public void LoadHistoryFromSQL()
        {
            ClearAllList();
            orderList = load.LoadOrderList(new LoadHistorySQL());
            LoadLVPriceAll();

        }

        private void ClearAllList()
        {
            form.ListViewDishes.Items.Clear();
            form.ListViewPrice.Items.Clear();
            orderList.Clear();
        }

        private void LoadLVPriceAll()
        {
            foreach (var price in orderList)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(price.PriceAll.ID));
                lvi.SubItems.Add(price.PriceAll.Date);
                lvi.SubItems.Add(price.PriceAll.Price);
                lvi.SubItems.Add(price.PriceAll.Comments);
                form.ListViewPrice.Items.Add(lvi);
            }
        }

        public void LoadLVDishes()
        {
            form.ListViewDishes.Items.Clear();
            foreach (var dish in orderList[form.ListViewPrice.FocusedItem.Index].ListDishes)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(dish.Id));
                lvi.SubItems.Add(dish.Name);
                lvi.SubItems.Add(dish.Price);
                lvi.SubItems.Add(dish.Sides);
                form.ListViewDishes.Items.Add(lvi);
            }
        }

    }
}
