using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;

namespace PizzaTest
{
    [TestClass]
    public class testForm1
    {
        [TestMethod]
        public void TestPriceSidePizza()
        {
            //Arrange
            Pizza.Form1 form1 = new Pizza.Form1();
            Pizza.LoadListOfSideDishes loadListOfSideDishes = new Pizza.LoadListOfSideDishes();

            List<string> sideDishes = loadListOfSideDishes.LoadSidePizza();

            //ATC
           
            foreach(var st in sideDishes)
            {
                int priceAll = form1.FindsPrice(st);
                Assert.AreEqual(2, priceAll);
            }


            //Assert
           
        }


        [TestMethod]
        public void TestPriceSideDania()
        {
            //Arrange
            Pizza.Form1 form1 = new Pizza.Form1();
            Pizza.LoadListOfSideDishes loadListOfSideDishes = new Pizza.LoadListOfSideDishes();

            List<string> sideDishes = loadListOfSideDishes.LoadSideDaniaGlowne();


            //ATC

            //foreach(var st in sideDishes)
            //{
            //    price.Add(form1.FindsPrice(st));
            //}
            int price = form1.FindsPrice(sideDishes[0]);
            Assert.AreEqual(5, price);

            price = form1.FindsPrice(sideDishes[1]);
            Assert.AreEqual(6, price);
            //Assert
            //check.Add(5);
            //check.Add(6);

        }

        [TestMethod]
        public void TestPriceListDaniaGlowne()
        {
            //Arrange
            Pizza.Form1 form1 = new Pizza.Form1();
            Pizza.ListOfDishes listOfDishes = new Pizza.ListOfDishes();

            List<Dish> lDishes = listOfDishes.LoadListDaniaGlowne();


       
            int price = form1.FindsPrice(lDishes[0].Price);
            Assert.AreEqual(30, price);

            price = form1.FindsPrice(lDishes[1].Price);
            Assert.AreEqual(28, price);

            price = form1.FindsPrice(lDishes[2].Price);
            Assert.AreEqual(27, price);

        }

        [TestMethod]
        public void TestPriceListPizza()
        {
            //Arrange
            Pizza.Form1 form1 = new Pizza.Form1();
            Pizza.ListOfDishes listOfDishes = new Pizza.ListOfDishes();

            List<Dish> lDishes = listOfDishes.LoadListPizza();

            int price = form1.FindsPrice(lDishes[0].Price);
            Assert.AreEqual(20, price);

            price = form1.FindsPrice(lDishes[1].Price);
            Assert.AreEqual(22, price);

            price = form1.FindsPrice(lDishes[2].Price);
            Assert.AreEqual(25, price);

            price = form1.FindsPrice(lDishes[3].Price);
            Assert.AreEqual(25, price);
        }

        [TestMethod]
        public void TestPriceListNapoje()
        {
            //Arrange
            Pizza.Form1 form1 = new Pizza.Form1();
            Pizza.ListOfDishes listOfDishes = new Pizza.ListOfDishes();

            List<Dish> lDishes = listOfDishes.LoadListNapoje();

            int price = form1.FindsPrice(lDishes[0].Price);
            Assert.AreEqual(5, price);

            price = form1.FindsPrice(lDishes[1].Price);
            Assert.AreEqual(5, price);

            price = form1.FindsPrice(lDishes[2].Price);
            Assert.AreEqual(5, price);
        }

        [TestMethod]
        public void TestPriceListZupy()
        {
            //Arrange
            Pizza.Form1 form1 = new Pizza.Form1();
            Pizza.ListOfDishes listOfDishes = new Pizza.ListOfDishes();

            List<Dish> lDishes = listOfDishes.LoadListZupy();

            int price = form1.FindsPrice(lDishes[0].Price);
            Assert.AreEqual(12, price);

            price = form1.FindsPrice(lDishes[1].Price);
            Assert.AreEqual(10, price);
        }

      


    }
}
