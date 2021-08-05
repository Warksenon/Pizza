using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;

namespace Test
{
    [TestClass]
    public class TestOrder
    {
        [TestMethod]
        public void TestPrice()
        {
            Order order = new Order();
            Assert.AreEqual("", order.PriceAll.Price);
            Assert.AreEqual("", order.PriceAll.Comments);
            Assert.AreEqual("", order.PriceAll.Date);

            string date = DateTime.Now.ToString();
            order.PriceAll.Price = "110zł";
            order.PriceAll.Comments = "One  beer please";
            order.PriceAll.Date = date;
            Assert.AreEqual("110zł", order.PriceAll.Price);
            Assert.AreEqual("One  beer please", order.PriceAll.Comments);
            Assert.AreEqual(date, order.PriceAll.Date);
        }


        [TestMethod]
        public void TestListDishesPizzza()
        {
            Order order = new Order();
            ListOfDishes list = new ListOfDishes();
            order.ListDishes = list.LoadListPizza();

            Assert.AreEqual("Margheritta", order.ListDishes[0].Name);
            Assert.AreEqual("20zł", order.ListDishes[0].Price);

            Assert.AreEqual("Vegetariana", order.ListDishes[1].Name);
            Assert.AreEqual("22zł", order.ListDishes[1].Price);

            Assert.AreEqual("Tosca", order.ListDishes[2].Name);
            Assert.AreEqual("25zł", order.ListDishes[2].Price);

            Assert.AreEqual("Venecia", order.ListDishes[3].Name);
            Assert.AreEqual("25zł", order.ListDishes[3].Price);
        }

        [TestMethod]
        public void TestListDishesMainDish()
        {
            Order order = new Order();
            ListOfDishes list = new ListOfDishes();
            order.ListDishes = list.LoadListMainDish();

            Assert.AreEqual("Schabowy z frytkami/ryżem/ziemniakami", order.ListDishes[0].Name);
            Assert.AreEqual("30zł", order.ListDishes[0].Price);

            Assert.AreEqual("Ryba z frytkami", order.ListDishes[1].Name);
            Assert.AreEqual("28zł", order.ListDishes[1].Price);

            Assert.AreEqual("Placek po węgiersku", order.ListDishes[2].Name);
            Assert.AreEqual("27zł", order.ListDishes[2].Price);
        }


        [TestMethod]
        public void TestListDishesSoups()
        {
            Order order = new Order();
            ListOfDishes list = new ListOfDishes();
            order.ListDishes = list.LoadListSoups();

            Assert.AreEqual("Pomidorowa", order.ListDishes[0].Name);
            Assert.AreEqual("12zł", order.ListDishes[0].Price);

            Assert.AreEqual("Rosół", order.ListDishes[1].Name);
            Assert.AreEqual("10zł", order.ListDishes[1].Price);
        }

        [TestMethod]
        public void TestListDishesDrinks()
        {
            Order order = new Order();
            ListOfDishes list = new ListOfDishes();
            order.ListDishes = list.LoadListDrinks();

            Assert.AreEqual("Kawa", order.ListDishes[0].Name);
            Assert.AreEqual("5zł", order.ListDishes[0].Price);

            Assert.AreEqual("Herbata", order.ListDishes[1].Name);
            Assert.AreEqual("5zł", order.ListDishes[1].Price);

            Assert.AreEqual("Cola", order.ListDishes[2].Name);
            Assert.AreEqual("5zł", order.ListDishes[2].Price);
        }

        [TestMethod]
        public void TestAddDishToListDisch()
        {
            Order order = new Order();
            ListOfDishes list = new ListOfDishes();
            List<Dish> lDishes = list.LoadListPizza();

            order.AddDishToListDisch(lDishes[0]);
            order.AddDishToListDisch(lDishes[1]);
            order.AddDishToListDisch(lDishes[2]);
            order.AddDishToListDisch(lDishes[3]);


            Assert.AreEqual("Margheritta", order.ListDishes[0].Name);
            Assert.AreEqual("20zł", order.ListDishes[0].Price);

            Assert.AreEqual("Vegetariana", order.ListDishes[1].Name);
            Assert.AreEqual("22zł", order.ListDishes[1].Price);

            Assert.AreEqual("Tosca", order.ListDishes[2].Name);
            Assert.AreEqual("25zł", order.ListDishes[2].Price);

            Assert.AreEqual("Venecia", order.ListDishes[3].Name);
            Assert.AreEqual("25zł", order.ListDishes[3].Price);

            lDishes = list.LoadListMainDish();
            order.AddDishToListDisch(lDishes[0]);
            order.AddDishToListDisch(lDishes[1]);
            order.AddDishToListDisch(lDishes[2]);

            Assert.AreEqual("Schabowy z frytkami/ryżem/ziemniakami", order.ListDishes[4].Name);
            Assert.AreEqual("30zł", order.ListDishes[4].Price);

            Assert.AreEqual("Ryba z frytkami", order.ListDishes[5].Name);
            Assert.AreEqual("28zł", order.ListDishes[5].Price);

            Assert.AreEqual("Placek po węgiersku", order.ListDishes[6].Name);
            Assert.AreEqual("27zł", order.ListDishes[6].Price);

            lDishes = list.LoadListSoups();
            order.AddDishToListDisch(lDishes[0]);
            order.AddDishToListDisch(lDishes[1]);

            Assert.AreEqual("Pomidorowa", order.ListDishes[7].Name);
            Assert.AreEqual("12zł", order.ListDishes[7].Price);

            Assert.AreEqual("Rosół", order.ListDishes[8].Name);
            Assert.AreEqual("10zł", order.ListDishes[8].Price);

            lDishes = list.LoadListDrinks();
            order.AddDishToListDisch(lDishes[0]);
            order.AddDishToListDisch(lDishes[1]);
            order.AddDishToListDisch(lDishes[2]);

            Assert.AreEqual("Kawa", order.ListDishes[9].Name);
            Assert.AreEqual("5zł", order.ListDishes[9].Price);

            Assert.AreEqual("Herbata", order.ListDishes[10].Name);
            Assert.AreEqual("5zł", order.ListDishes[10].Price);

            Assert.AreEqual("Cola", order.ListDishes[11].Name);
            Assert.AreEqual("5zł", order.ListDishes[11].Price);
        }
    }
}
