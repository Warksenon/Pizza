using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;
using Pizza.Presenters;

namespace Test
{
    [TestClass]
    public class TestOrderPresenters : IListViewDishes , IForm1Order
    {

        ListView lvDish = new ListView();
        CheckedListBox chSidesDish = new CheckedListBox();
        TForm1LoadDishesPresenters dishPresenter;
        TForm1OrderPresenters orderPresenters;

        public ListView ListViewDishes { get => lvDish; set => lvDish = value; }
        public CheckedListBox CheckedListBoxSideDish { get => chSidesDish; set => chSidesDish = value; }

        TextBox quantityDishes = new TextBox();
        TextBox comments = new TextBox();
        ListView lvOrder = new ListView();
        Label lPrice = new Label();
        BackgroundWorker worker = new BackgroundWorker();

        public TextBox TextBoxQuantityDishes { get => quantityDishes; set => quantityDishes = value; }
        public TextBox TextBoxComments { get => comments; set => comments = value; }
        public ListView ListViewOrder { get => lvOrder; set => lvOrder = value; }
        public Label LabelPrice { get => lPrice; set => lPrice = value; }
        public BackgroundWorker BackgroundWorker { get => worker; set => worker = value; }

        readonly Name name = new Name();

        [TestMethod]
        public void TestAddDishesToListViewOrderPizza()
        {
            dishPresenter = new TForm1LoadDishesPresenters(this);
            orderPresenters = new TForm1OrderPresenters(this, this);

            //Check add one dish without SidesDishe
            quantityDishes.Text = "1";
            dishPresenter.LoadPizza();
            dishPresenter.LoadSidesDishPizza();
            orderPresenters.AddDishesToListViewOrder(0);
            int i = 0;

            Assert.AreEqual(name.Margh, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("20zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(1);
            i = 1;

            Assert.AreEqual(name.Veget, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("22zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(2);
            i = 2;

            Assert.AreEqual(name.Tosca, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("25zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(3);
            i = 3;

            Assert.AreEqual(name.Venec, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("25zł", lvOrder.Items[i].SubItems[2].Text);
            lvDish.Clear();

            //Check add one dish with doubelchees
            dishPresenter.LoadPizza();
            chSidesDish.SetItemChecked(0, true);
            orderPresenters.AddDishesToListViewOrder(0);
            string sidesDish = "Podwójny Ser -2zł.";
            i = 4;


            Assert.AreEqual(name.MarghPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("22zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(1);
            i = 5;

            Assert.AreEqual(name.VegetPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("24zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(2);
            i = 6;

            Assert.AreEqual(name.ToscaPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("27zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(3);
            i = 7;

            Assert.AreEqual(name.VenecPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("27zł", lvOrder.Items[i].SubItems[2].Text);

            //Check add one dish with two sidesdish           
            chSidesDish.SetItemChecked(1, true);
            orderPresenters.AddDishesToListViewOrder(0);
            sidesDish = "Podwójny Ser -2zł, Salami -2zł.";
            i = 8;

            Assert.AreEqual(name.MarghPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("24zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(1);
            i = 9;

            Assert.AreEqual(name.VegetPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("26zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(2);
            i = 10;

            Assert.AreEqual(name.ToscaPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish,lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("29zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(3);
            i = 11;

            Assert.AreEqual(name.VenecPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("29zł", lvOrder.Items[i].SubItems[2].Text);

            //Check add one dish with three sidesdish            
            chSidesDish.SetItemChecked(2, true);
            orderPresenters.AddDishesToListViewOrder(0);
            sidesDish = "Podwójny Ser -2zł, Salami -2zł, Szynka -2zł.";
            i = 12;

            Assert.AreEqual(name.MarghPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("26zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(1);
            i = 13;

            Assert.AreEqual(name.VegetPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("28zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(2);
            i = 14;

            Assert.AreEqual(name.ToscaPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("31zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(3);
            i = 15;

            Assert.AreEqual(name.VenecPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("31zł", lvOrder.Items[i].SubItems[2].Text);

            //Check add one dish with four sidesdish            
            chSidesDish.SetItemChecked(3, true);
            orderPresenters.AddDishesToListViewOrder(0);
            sidesDish = "Podwójny Ser -2zł, Salami -2zł, Szynka -2zł, Pieczarki -2zł.";
            i = 16;

            Assert.AreEqual(name.MarghPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("28zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(1);
            i = 17;

            Assert.AreEqual(name.VegetPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("30zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(2);
            i = 18;

            Assert.AreEqual(name.ToscaPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("33zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(3);
            i = 19;

            Assert.AreEqual(name.VenecPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("33zł", lvOrder.Items[i].SubItems[2].Text);


            //Check add five dish and four sides dish
            quantityDishes.Text = "5";
            orderPresenters.AddDishesToListViewOrder(2);

            i = 20;
            Assert.AreEqual(name.ToscaPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("33zł", lvOrder.Items[i].SubItems[2].Text);

            i = 21;
            Assert.AreEqual(name.ToscaPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("33zł", lvOrder.Items[i].SubItems[2].Text);

            i = 22;
            Assert.AreEqual(name.ToscaPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("33zł", lvOrder.Items[i].SubItems[2].Text);

            i = 23;
            Assert.AreEqual(name.ToscaPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("33zł", lvOrder.Items[i].SubItems[2].Text);

            i = 24;
            Assert.AreEqual(name.ToscaPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("33zł", lvOrder.Items[i].SubItems[2].Text);
        }

        [TestMethod]
        public void TestAddDishesToListViewOrderMainDishes()
        {
            dishPresenter = new TForm1LoadDishesPresenters(this);
            orderPresenters = new TForm1OrderPresenters(this, this);
            lvOrder.Clear();

            //Check add one dish without SidesDishe
            quantityDishes.Text = "1";
            dishPresenter.LoadSidesDishMainDish();
            dishPresenter.LoadMainDish();
            orderPresenters.AddDishesToListViewOrder(0);
            int i = 0;

            Assert.AreEqual(name.Schnitzel, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("30zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(1);
            i = 1;

            Assert.AreEqual(name.Fish, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("28zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(2);
            i = 2;

            Assert.AreEqual(name.Potato, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("27zł", lvOrder.Items[i].SubItems[2].Text);

            //Check add one dish with salad bar

            chSidesDish.SetItemChecked(0, true);            
            orderPresenters.AddDishesToListViewOrder(0);
            string sidesDish = "Bar sałatkowy -5zł.";
            i = 3;


            Assert.AreEqual(name.SchnitzelPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("35zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(1);
            i = 4;

            Assert.AreEqual(name.FishPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("33zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(2);
            i = 5;

            Assert.AreEqual(name.PotatoPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("32zł", lvOrder.Items[i].SubItems[2].Text);

            //Check add one dish with two sides dish           
            chSidesDish.SetItemChecked(1, true);
            orderPresenters.AddDishesToListViewOrder(0);
            sidesDish = "Bar sałatkowy -5zł, Zestaw sosów -6zł.";
            i = 6;

            Assert.AreEqual(name.SchnitzelPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("41zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(1);
            i = 7;

            Assert.AreEqual(name.FishPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("39zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(2);
            i = 8;

            Assert.AreEqual(name.PotatoPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("38zł", lvOrder.Items[i].SubItems[2].Text);

            //Check add four dish and two sides dish
            quantityDishes.Text = "4";
            orderPresenters.AddDishesToListViewOrder(1);

            i = 9;
            Assert.AreEqual(name.FishPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("39zł", lvOrder.Items[i].SubItems[2].Text);

            i = 10;
            Assert.AreEqual(name.FishPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("39zł", lvOrder.Items[i].SubItems[2].Text);

            i = 11;
            Assert.AreEqual(name.FishPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("39zł", lvOrder.Items[i].SubItems[2].Text);

            i = 12;
            Assert.AreEqual(name.FishPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("39zł", lvOrder.Items[i].SubItems[2].Text);
        }

        [TestMethod]
        public void TestAddDishesToListViewOrderSoups()
        {
            dishPresenter = new TForm1LoadDishesPresenters(this);
            orderPresenters = new TForm1OrderPresenters(this, this);
            lvOrder.Clear();
            
            //Check add one dish 
            quantityDishes.Text = "1";           
            dishPresenter.LoadSoups();
            orderPresenters.AddDishesToListViewOrder(0);
            int i = 0;

            Assert.AreEqual(name.Tomato, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("12zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.AddDishesToListViewOrder(1);
            i = 1;

            Assert.AreEqual(name.ChickenSoup, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("10zł", lvOrder.Items[i].SubItems[2].Text);

            //Check add two dish 
            quantityDishes.Text = "2";
            orderPresenters.AddDishesToListViewOrder(0);

            i = 2;
            Assert.AreEqual(name.Tomato, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("12zł", lvOrder.Items[i].SubItems[2].Text);

            i = 3;
            Assert.AreEqual(name.Tomato, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("12zł", lvOrder.Items[i].SubItems[2].Text);

            //Check add three dish 
            quantityDishes.Text = "3";
            orderPresenters.AddDishesToListViewOrder(1);

            i = 4;
            Assert.AreEqual(name.ChickenSoup, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("10zł", lvOrder.Items[i].SubItems[2].Text);

            i = 5;
            Assert.AreEqual(name.ChickenSoup, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("10zł", lvOrder.Items[i].SubItems[2].Text);

            i = 6;
            Assert.AreEqual(name.ChickenSoup, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("10zł", lvOrder.Items[i].SubItems[2].Text);

        }

        [TestMethod]
        public void TestAddDishesToListViewOrderDrinks()
        {
            dishPresenter = new TForm1LoadDishesPresenters(this);
            orderPresenters = new TForm1OrderPresenters(this, this);
            lvOrder.Clear();

            //Check add one dish 
            quantityDishes.Text = "1";
            dishPresenter.LoadDrinks();

            int i = 0;
            orderPresenters.AddDishesToListViewOrder(i);
            
            Assert.AreEqual(name.Coffee, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("5zł", lvOrder.Items[i].SubItems[2].Text);

            i = 1;
            orderPresenters.AddDishesToListViewOrder(i);
           
            Assert.AreEqual(name.Tea, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("5zł", lvOrder.Items[i].SubItems[2].Text);

            i = 2;
            orderPresenters.AddDishesToListViewOrder(i);
            
            Assert.AreEqual(name.Cola, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("5zł", lvOrder.Items[i].SubItems[2].Text);

            //Check add three dish 
            quantityDishes.Text = "3";           
            orderPresenters.AddDishesToListViewOrder(1);

            i = 3;
            Assert.AreEqual(name.Tea, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("5zł", lvOrder.Items[i].SubItems[2].Text);

            i = 4;
            Assert.AreEqual(name.Tea, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("5zł", lvOrder.Items[i].SubItems[2].Text);

            i = 5;
            Assert.AreEqual(name.Tea, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("5zł", lvOrder.Items[i].SubItems[2].Text);
        }


        [TestMethod]
        public void TestLabelPrice()
        {
            dishPresenter = new TForm1LoadDishesPresenters(this);
            orderPresenters = new TForm1OrderPresenters(this, this);
            lvOrder.Clear();

            //Check add one dish 
            quantityDishes.Text = "1";
            dishPresenter.LoadMainDish();

            int i = 0;
            orderPresenters.AddDishesToListViewOrder(i);
            orderPresenters.LabelPrice();

            Assert.AreEqual("Cena: 30zł", lPrice.Text);

            i = 1;
            orderPresenters.AddDishesToListViewOrder(i);
            orderPresenters.LabelPrice();

            Assert.AreEqual("Cena: 58zł", lPrice.Text);

        }

        [TestMethod]
        public void TestSetListOrder()
        {
            dishPresenter = new TForm1LoadDishesPresenters(this);
            orderPresenters = new TForm1OrderPresenters(this, this);
            lvOrder.Clear();

            //Check add one dish 
            quantityDishes.Text = "1";
            dishPresenter.LoadDrinks();

            int i = 0;
            orderPresenters.AddDishesToListViewOrder(i);

            Assert.AreEqual(name.Coffee, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("5zł", lvOrder.Items[i].SubItems[2].Text);

            i = 1;
            orderPresenters.AddDishesToListViewOrder(i);

            Assert.AreEqual(name.Tea, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("5zł", lvOrder.Items[i].SubItems[2].Text);

            i = 2;
            orderPresenters.AddDishesToListViewOrder(i);

            Assert.AreEqual(name.Cola, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual("", lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("5zł", lvOrder.Items[i].SubItems[2].Text);

            orderPresenters.SetListDishes(lvOrder);
            Order orders = orderPresenters.GetOrder();

            i = 0;
            Assert.AreEqual(name.Coffee, orders.ListDishes[i].Name);
            Assert.AreEqual("", orders.ListDishes[i].SidesDishes);
            Assert.AreEqual("5zł", orders.ListDishes[i].Price);

            i = 1;
            Assert.AreEqual(name.Tea, orders.ListDishes[i].Name);
            Assert.AreEqual("", orders.ListDishes[i].SidesDishes);
            Assert.AreEqual("5zł", orders.ListDishes[i].Price);

            i = 2;
            Assert.AreEqual(name.Cola, orders.ListDishes[i].Name);
            Assert.AreEqual("", orders.ListDishes[i].SidesDishes);
            Assert.AreEqual("5zł", orders.ListDishes[i].Price);


            //Check add one dish with two sides dish 
            dishPresenter.LoadSidesDishMainDish();
            dishPresenter.LoadMainDish();
            chSidesDish.SetItemChecked(0, true);
            chSidesDish.SetItemChecked(1, true);
            orderPresenters.AddDishesToListViewOrder(0);
            string sidesDish = "Bar sałatkowy -5zł, Zestaw sosów -6zł.";
            i = 3;

            Assert.AreEqual(name.SchnitzelPrice, lvOrder.Items[i].SubItems[0].Text);
            Assert.AreEqual(sidesDish, lvOrder.Items[i].SubItems[1].Text);
            Assert.AreEqual("41zł", lvOrder.Items[i].SubItems[2].Text);


            orderPresenters.SetListDishes(lvOrder);
            orders = orderPresenters.GetOrder();

            Assert.AreEqual(name.SchnitzelPrice, orders.ListDishes[i].Name);
            Assert.AreEqual(sidesDish, orders.ListDishes[i].SidesDishes);
            Assert.AreEqual("41zł", orders.ListDishes[i].Price);

        }

        [TestMethod]
        public void TestSetCommentsAndDate()
        {            
            orderPresenters = new TForm1OrderPresenters(this, this);
            string comments = "please don't burn";
            orderPresenters.SetCommentsAndDate(comments);
            string date = DateTime.Now.ToString();
            Order order = orderPresenters.GetOrder();
            
            Assert.AreEqual(comments, order.PriceAll.Comments);
            Assert.AreEqual(date, order.PriceAll.Date);
        }

    }
}
