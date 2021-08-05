using Pizza.Models.Menu;
using Pizza.Presenters.PresenterForm1.LoadDishesAndSideDishForm1;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizza.Presenters
{
    class Form1LoadDishesPresenters
    {
        private readonly IForm1ListViewDishes loadDishes;
 
        public Form1LoadDishesPresenters(FormMenu form1)
        {
            loadDishes = form1;
            
        }

        public void LoadPizza()
        {
            AddDishesToListView(new ListPizza());          
        }

        public void LoadMainDish()
        {
           AddDishesToListView(new ListMainDishes());          
        }

        public void LoadSoups()
        {
           AddDishesToListView(new ListSoups());         
        }

        public void LoadDrinks()
        {
           AddDishesToListView(new ListDrinks());         
        }

        private void AddDishesToListView(IForm1Dishes loadList)
        {
            List<Dish> listDisch = loadList.GetDishes();
            loadDishes.ListViewDishes.Items.Clear();
            foreach (var disch in listDisch)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(disch.Name));
                lvi.SubItems.Add(disch.Price);
                loadDishes.ListViewDishes.Items.Add(lvi);
            }
        }

    }
}
