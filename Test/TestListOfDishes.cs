using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class TestListOfDishes
    {
        [TestMethod]
        public void TestPizza()
        {
            ListOfDishes list = new ListOfDishes();

            List<Dish> listPizza = list.LoadListPizza();

            Assert.AreEqual("Margheritta", listPizza[0].Name);
            Assert.AreEqual("20zł", listPizza[0].Price);

            Assert.AreEqual("Vegetariana", listPizza[1].Name);
            Assert.AreEqual("22zł", listPizza[1].Price);

            Assert.AreEqual("Tosca", listPizza[2].Name);
            Assert.AreEqual("25zł", listPizza[2].Price);

            Assert.AreEqual("Venecia", listPizza[3].Name);
            Assert.AreEqual("25zł", listPizza[3].Price);
        }

        [TestMethod]
        public void TestMainDisha()
        {

            ListOfDishes list = new ListOfDishes();

            List<Dish> listPizza = list.LoadListMainDish();

            Assert.AreEqual("Schabowy z frytkami/ryżem/ziemniakami", listPizza[0].Name);
            Assert.AreEqual("30zł", listPizza[0].Price);

            Assert.AreEqual("Ryba z frytkami", listPizza[1].Name);
            Assert.AreEqual("28zł", listPizza[1].Price);

            Assert.AreEqual("Placek po węgiersku", listPizza[2].Name);
            Assert.AreEqual("27zł", listPizza[2].Price);

        }

        [TestMethod]
        public void TestSoups()
        {
            ListOfDishes list = new ListOfDishes();
            List<Dish> listPizza = list.LoadListSoups();

            Assert.AreEqual("Pomidorowa", listPizza[0].Name);
            Assert.AreEqual("12zł", listPizza[0].Price);

            Assert.AreEqual("Rosół", listPizza[1].Name);
            Assert.AreEqual("10zł", listPizza[1].Price);

        }

        [TestMethod]
        public void TestDrinks()
        {
            ListOfDishes list = new ListOfDishes();
            List<Dish> listPizza = list.LoadListDrinks();

            Assert.AreEqual("Kawa", listPizza[0].Name);
            Assert.AreEqual("5zł", listPizza[0].Price);

            Assert.AreEqual("Herbata", listPizza[1].Name);
            Assert.AreEqual("5zł", listPizza[1].Price);

            Assert.AreEqual("Cola", listPizza[2].Name);
            Assert.AreEqual("5zł", listPizza[2].Price);
        }
    }
}
